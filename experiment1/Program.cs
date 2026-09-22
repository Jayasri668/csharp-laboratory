using System;

Console.WriteLine("ELECTRICITY BILL CALCULATOR");
Console.WriteLine("----------------------------");

Console.Write("Enter customer name: ");
string customerName = Console.ReadLine() ?? "Customer";

Console.Write("Enter units consumed: ");

if (!double.TryParse(Console.ReadLine(), out double units) || units < 0)
{
    Console.WriteLine("Please enter a valid non-negative number of units.");
    return;
}

double energyCharge;

if (units <= 100)
{
    energyCharge = units * 1.50;
}
else if (units <= 200)
{
    energyCharge = (100 * 1.50) + ((units - 100) * 2.50);
}
else if (units <= 500)
{
    energyCharge = (100 * 1.50) + (100 * 2.50) + ((units - 200) * 4.00);
}
else
{
    energyCharge =
        (100 * 1.50) +
        (100 * 2.50) +
        (300 * 4.00) +
        ((units - 500) * 6.00);
}

double fixedCharge = 75.00;
double surcharge = 0;

if (energyCharge > 1000)
{
    surcharge = energyCharge * 0.05;
}

double totalBill = energyCharge + fixedCharge + surcharge;

Console.WriteLine();
Console.WriteLine("--------- ELECTRICITY BILL ---------");
Console.WriteLine($"Customer Name : {customerName}");
Console.WriteLine($"Units Used    : {units}");
Console.WriteLine($"Energy Charge : Rs. {energyCharge:F2}");
Console.WriteLine($"Fixed Charge  : Rs. {fixedCharge:F2}");
Console.WriteLine($"Surcharge     : Rs. {surcharge:F2}");
Console.WriteLine("------------------------------------");
Console.WriteLine($"Total Amount  : Rs. {totalBill:F2}");
Console.WriteLine("------------------------------------");