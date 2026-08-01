using System;
using System.Collections.Generic;
using System.Linq;

// -------------------------
// Custom Exception
// -------------------------
public class InvalidCacheKeyException : Exception
{
    public InvalidCacheKeyException(string message)
        : base(message)
    {
    }
}

// -------------------------
// Sample Classes
// -------------------------
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public string Product { get; set; }
}

// -------------------------
// Generic Cache Manager
// -------------------------
public class CacheManager<T>
{
    private Dictionary<string, T> cache = new Dictionary<string, T>();

    // Add
    public void Add(string key, T value)
    {
        cache[key] = value;
    }

    // Remove
    public void Remove(string key)
    {
        if (!cache.ContainsKey(key))
            throw new InvalidCacheKeyException("Key not found.");

        cache.Remove(key);
    }

    // GetByKey
    public T GetByKey(string key)
    {
        if (!cache.ContainsKey(key))
            throw new InvalidCacheKeyException("Invalid Cache Key.");

        return cache[key];
    }

    // Clear
    public void Clear()
    {
        cache.Clear();
    }

    // Indexer
    public T this[string key]
    {
        get
        {
            return GetByKey(key);
        }
    }

    // Property for extension methods
    public Dictionary<string, T> Cache
    {
        get { return cache; }
    }
}

// -------------------------
// Extension Methods
// -------------------------
public static class CacheExtensions
{
    // Get All Keys
    public static List<string> GetAllKeys<T>(this CacheManager<T> cache)
    {
        return cache.Cache.Keys.ToList();
    }

    // Dummy Expired Count
    public static int CountExpiredItems<T>(this CacheManager<T> cache)
    {
        return 0;
    }
}

// -------------------------
// Main
// -------------------------
public class Program
{
    public static void Main()
    {
        CacheManager<int> numberCache = new CacheManager<int>();

        numberCache.Add("One", 1);
        numberCache.Add("Two", 2);

        Console.WriteLine(numberCache["One"]);

        Console.WriteLine();

        CacheManager<Customer> customerCache = new CacheManager<Customer>();

        customerCache.Add("C1",
            new Customer
            {
                Id = 101,
                Name = "John"
            });

        Console.WriteLine(customerCache["C1"].Name);

        Console.WriteLine();

        Console.WriteLine("Keys:");

        foreach (var key in customerCache.GetAllKeys())
        {
            Console.WriteLine(key);
        }

        Console.WriteLine();

        Console.WriteLine("Expired Items: "
            + customerCache.CountExpiredItems());
    }
}