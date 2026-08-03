using System;
using System.Collections.Generic;

namespace Entities
{
    // Partial Class - Part 1
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Partial Class - Part 2
    public partial class Employee
    {
        public void Display()
        {
            Console.WriteLine($"Employee Id : {Id}");
            Console.WriteLine($"Employee Name : {Name}");
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

namespace ORM
{
    public class Database
    {
        public void Save<T>(T obj)
        {
            Console.WriteLine(typeof(T).Name + " Saved Successfully");
        }

        public T Get<T>(int id) where T : new()
        {
            Console.WriteLine(typeof(T).Name + " Retrieved with Id : " + id);
            return new T();
        }

        public void Delete<T>(int id)
        {
            Console.WriteLine(typeof(T).Name + " Deleted with Id : " + id);
        }

        // Bonus
        public List<T> GetAll<T>() where T : new()
        {
            Console.WriteLine("Getting all " + typeof(T).Name + " records");
            return new List<T>();
        }
    }
}

namespace MiniORMApp
{
    using Entities;
    using ORM;

    class Program
    {
        static void Main()
        {
            Database db = new Database();

            // Object Initializer
            Employee emp = new Employee
            {
                Id = 1,
                Name = "Sai"
            };

            db.Save(emp);

            Employee e = db.Get<Employee>(1);

            db.Delete<Order>(5);

            List<Customer> customers = db.GetAll<Customer>();

            Console.WriteLine();

            emp.Display();
        }
    }
}