using System;

// Abstract Class
public abstract class Vehicle
{
    public string VehicleNumber { get; set; }

    public abstract void VehicleType();
}

// Driver Class
public class Driver : Vehicle
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                name = value;
            else
                Console.WriteLine("Invalid Driver Name");
        }
    }

    public bool IsAvailable { get; set; }

    public override void VehicleType()
    {
        Console.WriteLine("Vehicle Type : Car");
    }
}

// Rider Class
public class Rider
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                name = value;
            else
                Console.WriteLine("Invalid Rider Name");
        }
    }
}

// Ride Class
public class Ride
{
    private double distance;

    public Driver Driver { get; set; }
    public Rider Rider { get; set; }

    public double Distance
    {
        get { return distance; }
        set
        {
            if (value > 0)
                distance = value;
            else
                Console.WriteLine("Distance must be greater than 0");
        }
    }

    public double Fare { get; set; }

    public virtual void DisplayRide()
    {
        Console.WriteLine("\n----- Ride Details -----");
        Console.WriteLine("Driver   : " + Driver.Name);
        Console.WriteLine("Rider    : " + Rider.Name);
        Console.WriteLine("Distance : " + Distance + " km");
        Console.WriteLine("Fare     : ₹" + Fare);
    }
}

// Sealed Class
public sealed class CompletedRide : Ride
{
    public override void DisplayRide()
    {
        Console.WriteLine("Ride Completed Successfully!");
        base.DisplayRide();
    }
}

// Generic Class
public class DriverMatcher<T> where T : Driver
{
    public T MatchDriver(T driver)
    {
        if (driver.IsAvailable)
        {
            Console.WriteLine("Driver Matched Successfully");
            return driver;
        }

        Console.WriteLine("No Driver Available");
        return null;
    }
}

// Extension Methods
public static class RideExtensions
{
    public static double CalculateDistance(this Ride ride)
    {
        return ride.Distance;
    }

    public static double CalculateFare(this Ride ride)
    {
        return ride.Distance * 15;
    }
}

// Main Class
class Program
{
    static void Main()
    {
        Driver driver = new Driver
        {
            Name = "Rahul",
            VehicleNumber = "AP39AB1234",
            IsAvailable = true
        };

        Rider rider = new Rider
        {
            Name = "Sai"
        };

        DriverMatcher<Driver> matcher = new DriverMatcher<Driver>();

        Driver matchedDriver = matcher.MatchDriver(driver);

        if (matchedDriver != null)
        {
            CompletedRide ride = new CompletedRide();

            ride.Driver = matchedDriver;
            ride.Rider = rider;
            ride.Distance = 10;

            ride.Fare = ride.CalculateFare();

            matchedDriver.VehicleType();

            ride.DisplayRide();

            Console.WriteLine("\nExtension Methods");
            Console.WriteLine("Distance : " + ride.CalculateDistance() + " km");
            Console.WriteLine("Fare     : ₹" + ride.CalculateFare());
        }
    }
}