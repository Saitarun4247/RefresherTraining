using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // In-memory storage
    static List<dynamic> books = new List<dynamic>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== BOOK LIBRARY MANAGEMENT =====");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AdminMenu();
                    break;

                case 2:
                    UserMenu();
                    break;

                case 3:
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    // ================= ADMIN =================

    static void AdminMenu()
    {
        while (true)
        {
            Console.WriteLine("\n===== ADMIN MENU =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Update Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. View All Books");
            Console.WriteLine("5. Back");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddBook();
                    break;

                case 2:
                    UpdateBook();
                    break;

                case 3:
                    DeleteBook();
                    break;

                case 4:
                    ViewAllBooks();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    // ================= USER =================

    static void UserMenu()
    {
        while (true)
        {
            Console.WriteLine("\n===== USER MENU =====");
            Console.WriteLine("1. Browse Books");
            Console.WriteLine("2. Search by Name");
            Console.WriteLine("3. Search by Publisher");
            Console.WriteLine("4. Highest Price Book");
            Console.WriteLine("5. Lowest Price Book");
            Console.WriteLine("6. Back");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ViewAllBooks();
                    break;

                case 2:
                    SearchByName();
                    break;

                case 3:
                    SearchByPublisher();
                    break;

                case 4:
                    HighestPriceBook();
                    break;

                case 5:
                    LowestPriceBook();
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    // ================= CRUD =================

    static void AddBook()
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        // Check duplicate ID
        if (books.Any(b => b.Id == id))
        {
            Console.WriteLine("Book ID already exists.");
            return;
        }

        Console.Write("Enter Book Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Publisher: ");
        string publisher = Console.ReadLine();

        Console.Write("Enter Price: ");
        double price = double.Parse(Console.ReadLine());

        dynamic book = new
        {
            Id = id,
            Name = name,
            Publisher = publisher,
            Price = price
        };

        books.Add(book);

        Console.WriteLine("Book added successfully.");
    }

    static void UpdateBook()
    {
        Console.Write("Enter Book ID to update: ");
        int id = int.Parse(Console.ReadLine());

        int index = books.FindIndex(b => b.Id == id);

        if (index == -1)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        Console.Write("Enter new Book Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter new Publisher: ");
        string publisher = Console.ReadLine();

        Console.Write("Enter new Price: ");
        double price = double.Parse(Console.ReadLine());

        dynamic updatedBook = new
        {
            Id = id,
            Name = name,
            Publisher = publisher,
            Price = price
        };

        books[index] = updatedBook;

        Console.WriteLine("Book updated successfully.");
    }

    static void DeleteBook()
    {
        Console.Write("Enter Book ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        dynamic book = books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        books.Remove(book);

        Console.WriteLine("Book deleted successfully.");
    }

    // ================= VIEW =================

    static void ViewAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        Console.WriteLine("\nID\tName\t\tPublisher\tPrice");

        foreach (dynamic book in books)
        {
            Console.WriteLine(
                $"{book.Id}\t{book.Name}\t\t{book.Publisher}\t\t{book.Price:F2}"
            );
        }
    }

    // ================= SEARCH =================

    static void SearchByName()
    {
        Console.Write("Enter book name: ");
        string name = Console.ReadLine();

        var result = books
            .Where(b => b.Name
            .Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();

        DisplaySearchResult(result);
    }

    static void SearchByPublisher()
    {
        Console.Write("Enter publisher: ");
        string publisher = Console.ReadLine();

        var result = books
            .Where(b => b.Publisher
            .Contains(publisher, StringComparison.OrdinalIgnoreCase))
            .ToList();

        DisplaySearchResult(result);
    }

    static void DisplaySearchResult(List<dynamic> result)
    {
        if (result.Count == 0)
        {
            Console.WriteLine("No matching books found.");
            return;
        }

        foreach (dynamic book in result)
        {
            Console.WriteLine(
                $"ID: {book.Id}, " +
                $"Name: {book.Name}, " +
                $"Publisher: {book.Publisher}, " +
                $"Price: {book.Price:F2}"
            );
        }
    }

    // ================= PRICE =================

    static void HighestPriceBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        dynamic book = books
            .OrderByDescending(b => b.Price)
            .First();

        Console.WriteLine("\nHighest Priced Book:");
        Console.WriteLine($"ID: {book.Id}");
        Console.WriteLine($"Name: {book.Name}");
        Console.WriteLine($"Publisher: {book.Publisher}");
        Console.WriteLine($"Price: {book.Price:F2}");
    }

    static void LowestPriceBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        dynamic book = books
            .OrderBy(b => b.Price)
            .First();

        Console.WriteLine("\nLowest Priced Book:");
        Console.WriteLine($"ID: {book.Id}");
        Console.WriteLine($"Name: {book.Name}");
        Console.WriteLine($"Publisher: {book.Publisher}");
        Console.WriteLine($"Price: {book.Price:F2}");
    }
}