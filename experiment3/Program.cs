using System;

class Employee
{
    public string Name { get; set; }
    public int EmployeeId { get; set; }

    public Employee(string name, int employeeId)
    {
        Name = name;
        EmployeeId = employeeId;
    }

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"Employee Name : {Name}");
        Console.WriteLine($"Employee ID   : {EmployeeId}");
    }
}

// Single inheritance: TechnicalEmployee inherits Employee
class TechnicalEmployee : Employee
{
    public string Department { get; set; }

    public TechnicalEmployee(
        string name,
        int employeeId,
        string department)
        : base(name, employeeId)
    {
        Department = department;
    }

    public void DisplayDepartment()
    {
        Console.WriteLine($"Department    : {Department}");
    }
}

// Multilevel inheritance: Developer inherits TechnicalEmployee
class Developer : TechnicalEmployee
{
    public string ProgrammingLanguage { get; set; }

    public Developer(
        string name,
        int employeeId,
        string department,
        string programmingLanguage)
        : base(name, employeeId, department)
    {
        ProgrammingLanguage = programmingLanguage;
    }

    public void DevelopApplication()
    {
        Console.WriteLine(
            $"{Name} develops applications using {ProgrammingLanguage}.");
    }
}

// Multiple inheritance is achieved using interfaces in C#
interface IProjectPlanner
{
    void PlanProject();
}

interface ILeaveApprover
{
    void ApproveLeave();
}

class ProjectManager : Employee, IProjectPlanner, ILeaveApprover
{
    public string ProjectName { get; set; }

    public ProjectManager(
        string name,
        int employeeId,
        string projectName)
        : base(name, employeeId)
    {
        ProjectName = projectName;
    }

    public void PlanProject()
    {
        Console.WriteLine($"Project planned: {ProjectName}");
    }

    public void ApproveLeave()
    {
        Console.WriteLine($"{Name} approved an employee leave request.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("EMPLOYEE HIERARCHY");
        Console.WriteLine("==================");

        Console.WriteLine("\nDeveloper Details");
        Console.WriteLine("-----------------");

        Developer developer = new Developer(
            "Meera",
            101,
            "Technology",
            "C#");

        developer.DisplayEmployeeDetails();
        developer.DisplayDepartment();
        developer.DevelopApplication();

        Console.WriteLine("\nProject Manager Details");
        Console.WriteLine("-----------------------");

        ProjectManager manager = new ProjectManager(
            "Arun",
            102,
            "Hospital Management System");

        manager.DisplayEmployeeDetails();
        manager.PlanProject();
        manager.ApproveLeave();
    }
}