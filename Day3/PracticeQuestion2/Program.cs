using System;
using System.Collections.Generic;

// Interface 1
interface IRegistrable
{
    void Register();
}

// Interface 2
interface INotifiable
{
    void NotifyUser();
}

// Event Class
class Event : IRegistrable, INotifiable
{
    private int eventId;
    private string eventName;
    private string eventType;

    public int EventId
    {
        get { return eventId; }
        set
        {
            if (value > 0)
                eventId = value;
            else
                Console.WriteLine("Invalid Event Id");
        }
    }

    public string EventName
    {
        get { return eventName; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                eventName = value;
            else
                Console.WriteLine("Invalid Event Name");
        }
    }

    public string EventType
    {
        get { return eventType; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                eventType = value;
            else
                Console.WriteLine("Invalid Event Type");
        }
    }

    public void Register()
    {
        Console.WriteLine("Registration Successful");
    }

    public void NotifyUser()
    {
        Console.WriteLine("Notification Sent");
    }
}

// Generic Event Manager
class EventManager<T> where T : Event
{
    private Dictionary<int, T> events = new Dictionary<int, T>();

    public void AddEvent(T ev)
    {
        events.Add(ev.EventId, ev);
    }

    // Indexer -> events[101]
    public T this[int id]
    {
        get
        {
            return events[id];
        }
    }
}

// Extension Method
static class EventExtension
{
    public static void SendReminder(this Event ev)
    {
        Console.WriteLine("Reminder sent for " + ev.EventName);
    }
}

class Program
{
    static void Main()
    {
        EventManager<Event> manager = new EventManager<Event>();

        Event e1 = new Event
        {
            EventId = 101,
            EventName = "AI Conference",
            EventType = "Conference"
        };

        Event e2 = new Event
        {
            EventId = 102,
            EventName = "C# Workshop",
            EventType = "Workshop"
        };

        Event e3 = new Event
        {
            EventId = 103,
            EventName = "Cloud Webinar",
            EventType = "Webinar"
        };

        manager.AddEvent(e1);
        manager.AddEvent(e2);
        manager.AddEvent(e3);

        // Interface Methods
        e1.Register();
        e1.NotifyUser();

        // Extension Method
        e1.SendReminder();

        Console.WriteLine();

        // Indexer
        Event ev = manager[101];

        Console.WriteLine("Event Id : " + ev.EventId);
        Console.WriteLine("Event Name : " + ev.EventName);
        Console.WriteLine("Event Type : " + ev.EventType);

        Console.WriteLine();

        // Anonymous Type
        var summary = new
        {
            ev.EventId,
            ev.EventName,
            ev.EventType
        };

        Console.WriteLine("Anonymous Type Summary");
        Console.WriteLine(summary.EventId);
        Console.WriteLine(summary.EventName);
        Console.WriteLine(summary.EventType);
    }
}