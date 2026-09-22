using System;

class OrderStatusEventArgs : EventArgs
{
    public string OrderNumber { get; set; }
    public string ProductName { get; set; }
    public string Status { get; set; }

    public OrderStatusEventArgs(
        string orderNumber,
        string productName,
        string status)
    {
        OrderNumber = orderNumber;
        ProductName = productName;
        Status = status;
    }
}

class ShoppingOrder
{
    public string OrderNumber { get; set; }
    public string ProductName { get; set; }

    public event EventHandler<OrderStatusEventArgs>? StatusChanged;

    public ShoppingOrder(
        string orderNumber,
        string productName)
    {
        OrderNumber = orderNumber;
        ProductName = productName;
    }

    public void ChangeOrderStatus(string newStatus)
    {
        Console.WriteLine(
            $"\nChanging order status to: {newStatus}");

        OrderStatusEventArgs eventData =
            new OrderStatusEventArgs(
                OrderNumber,
                ProductName,
                newStatus);

        OnStatusChanged(eventData);
    }

    protected virtual void OnStatusChanged(
        OrderStatusEventArgs eventData)
    {
        if (StatusChanged != null)
        {
            StatusChanged(this, eventData);
        }
    }
}

class Program
{
    static void SendCustomerNotification(
        object? sender,
        OrderStatusEventArgs eventData)
    {
        Console.WriteLine(
            $"Customer Notification: Order {eventData.OrderNumber} " +
            $"for {eventData.ProductName} is {eventData.Status}.");
    }

    static void UpdateStoreDisplay(
        object? sender,
        OrderStatusEventArgs eventData)
    {
        Console.WriteLine(
            $"Store Display: {eventData.ProductName} is now " +
            $"marked as {eventData.Status}.");
    }

    static void Main()
    {
        Console.WriteLine("ONLINE SHOPPING ORDER TRACKER");
        Console.WriteLine("=============================");

        ShoppingOrder order = new ShoppingOrder(
            "ORD-204",
            "Wireless Headphones");

        order.StatusChanged += SendCustomerNotification;
        order.StatusChanged += UpdateStoreDisplay;

        order.ChangeOrderStatus("Packed");
        order.ChangeOrderStatus("Out for Delivery");
        order.ChangeOrderStatus("Delivered");
    }
}