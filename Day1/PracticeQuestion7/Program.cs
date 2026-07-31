using System;

class Employee
{
    public string Name { get; set; }
    public double HoursWorked { get; set; }
    public double HourlyRate { get; set; }

    public Employee(string name, double hoursWorked, double hourlyRate)
    {
        Name = name;
        HoursWorked = hoursWorked;
        HourlyRate = hourlyRate;
    }
}

class PayrollCalculator
{
    public double CalculateRegularPay(Employee employee)
    {
        double regularHours = Math.Min(employee.HoursWorked, 40);
        return regularHours * employee.HourlyRate;
    }

    public double CalculateOvertimePay(Employee employee)
    {
        if (employee.HoursWorked > 40)
        {
            double overtimeHours = employee.HoursWorked - 40;
            return overtimeHours * employee.HourlyRate * 1.5;
        }

        return 0;
    }

    public double CalculateGrossSalary(Employee employee)
    {
        return CalculateRegularPay(employee) + CalculateOvertimePay(employee);
    }
}

class Program
{
    static void Main()
    {
        string name;
        double hoursWorked;
        double hourlyRate;

        Console.Write("Enter employee name: ");
        name = Console.ReadLine() ?? "";

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Employee name cannot be empty.");
            Console.Write("Enter employee name: ");
            name = Console.ReadLine() ?? "";
        }

        Console.Write("Enter hours worked: ");

        while (!double.TryParse(Console.ReadLine(), out hoursWorked) ||
               hoursWorked < 0 || hoursWorked > 168)
        {
            Console.WriteLine("Invalid hours. Enter a value between 0 and 168.");
            Console.Write("Enter hours worked: ");
        }

        Console.Write("Enter hourly rate: ");

        while (!double.TryParse(Console.ReadLine(), out hourlyRate) ||
               hourlyRate <= 0)
        {
            Console.WriteLine("Invalid hourly rate. Enter a positive number.");
            Console.Write("Enter hourly rate: ");
        }

        Employee employee = new Employee(name, hoursWorked, hourlyRate);

        PayrollCalculator calculator = new PayrollCalculator();

        double regularPay = calculator.CalculateRegularPay(employee);
        double overtimePay = calculator.CalculateOvertimePay(employee);
        double grossSalary = calculator.CalculateGrossSalary(employee);

        regularPay = Math.Round(regularPay, 2);
        overtimePay = Math.Round(overtimePay, 2);
        grossSalary = Math.Round(grossSalary, 2);

        Console.WriteLine("\n----- PAYROLL DETAILS -----");
        Console.WriteLine($"Employee Name: {employee.Name}");
        Console.WriteLine($"Hours Worked: {employee.HoursWorked:F2}");
        Console.WriteLine($"Hourly Rate: {employee.HourlyRate:F2}");
        Console.WriteLine($"Regular Pay: {regularPay:F2}");
        Console.WriteLine($"Overtime Pay: {overtimePay:F2}");
        Console.WriteLine($"Gross Salary: {grossSalary:F2}");
    }
}