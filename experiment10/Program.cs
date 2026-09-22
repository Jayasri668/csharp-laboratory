using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            @"Data Source=.\SQLEXPRESS;
              Initial Catalog=College;
              Integrated Security=True;
              TrustServerCertificate=True";

        string query =
            "SELECT Id, Name, Department, Salary FROM Employee";

        Console.WriteLine(
            "EMPLOYEE DATABASE VIEWER - DISCONNECTED ENVIRONMENT");

        Console.WriteLine(
            "===============================================");

        try
        {
            SqlDataAdapter adapter =
                new SqlDataAdapter(query, connectionString);

            DataSet employeeDataSet = new DataSet();

            // The adapter retrieves records and stores them in memory.
            adapter.Fill(employeeDataSet, "Employees");

            DataTable employeeTable =
                employeeDataSet.Tables["Employees"];

            if (employeeTable.Rows.Count == 0)
            {
                Console.WriteLine(
                    "\nNo employee records are available.");

                return;
            }

            Console.WriteLine();
            Console.WriteLine(
                "ID\tName\t\tDepartment\tSalary");

            Console.WriteLine(
                "--------------------------------------------------------");

            foreach (DataRow employeeRow in employeeTable.Rows)
            {
                Console.WriteLine(
                    $"{employeeRow["Id"]}\t" +
                    $"{employeeRow["Name"]}\t\t" +
                    $"{employeeRow["Department"]}\t" +
                    $"Rs. {employeeRow["Salary"]}");
            }

            Console.WriteLine(
                "--------------------------------------------------------");

            Console.WriteLine(
                $"\nTotal Employees Retrieved: {employeeTable.Rows.Count}");

            Console.WriteLine(
                "\nData was retrieved using SqlDataAdapter and DataSet.");
        }
        catch (SqlException exception)
        {
            Console.WriteLine(
                "\nUnable to connect to SQL Server Express.");

            Console.WriteLine(
                "Check that .\\SQLEXPRESS is running and that the " +
                "College database contains the Employee table.");

            Console.WriteLine(
                $"\nDatabase Error: {exception.Message}");
        }
    }
}