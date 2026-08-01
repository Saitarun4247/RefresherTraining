using System;
using System.Collections.Generic;

public class ExpenseRequest
{
    public string EmployeeName { get; set; }
    public double Amount { get; set; }

    public ExpenseRequest(string employeeName, double amount)
    {
        EmployeeName = employeeName;
        Amount = amount;
    }
}

// Abstract Handler
public abstract class Approver
{
    protected Approver NextApprover;

    public void SetNext(Approver next)
    {
        NextApprover = next;
    }

    public abstract void Approve(ExpenseRequest request);
}

// Team Lead
public class TeamLead : Approver
{
    public override void Approve(ExpenseRequest request)
    {
        if (request.Amount <= 10000)
        {
            Console.WriteLine($"Team Lead approved ₹{request.Amount} for {request.EmployeeName}");
        }
        else if (NextApprover != null)
        {
            NextApprover.Approve(request);
        }
    }
}

// Manager
public class Manager : Approver
{
    public override void Approve(ExpenseRequest request)
    {
        if (request.Amount <= 50000)
        {
            Console.WriteLine($"Manager approved ₹{request.Amount} for {request.EmployeeName}");
        }
        else if (NextApprover != null)
        {
            NextApprover.Approve(request);
        }
    }
}

// Director
public class Director : Approver
{
    public override void Approve(ExpenseRequest request)
    {
        Console.WriteLine($"Director approved ₹{request.Amount} for {request.EmployeeName}");
    }
}

public class Program
{
    public static void Main()
    {
        TeamLead teamLead = new TeamLead();
        Manager manager = new Manager();
        Director director = new Director();

        teamLead.SetNext(manager);
        manager.SetNext(director);

        List<ExpenseRequest> requests = new List<ExpenseRequest>
        {
            new ExpenseRequest("Alice",8000),
            new ExpenseRequest("Bob",25000),
            new ExpenseRequest("Charlie",120000)
        };

        foreach (var request in requests)
        {
            teamLead.Approve(request);
        }
    }
}