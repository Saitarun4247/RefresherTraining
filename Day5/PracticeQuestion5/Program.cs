using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        LinkedList<string> studentList = new LinkedList<string>();

        while (true)
        {
            Console.WriteLine("LinkedList Operations:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student by Name");
            Console.WriteLine("5. Clear List");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice (1-6): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent(studentList);
                    break;

                case 2:
                    DisplayStudents(studentList);
                    break;

                case 3:
                    UpdateStudent(studentList);
                    break;

                case 4:
                    DeleteStudentByName(studentList);
                    break;

                case 5:
                    ClearList(studentList);
                    break;

                case 6:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    public static void AddStudent(LinkedList<string> studentList)
    {
        Console.Write("Enter student name to add: ");
        string name = Console.ReadLine();

        studentList.AddLast(name);

        Console.WriteLine($"{name} added to the list.");
    }

    public static void DisplayStudents(LinkedList<string> studentList)
    {
        Console.WriteLine("Students in the list:");

        foreach (string student in studentList)
        {
            Console.WriteLine(student);
        }
    }

    public static void UpdateStudent(LinkedList<string> studentList)
    {
        Console.Write("Enter the current student name to update: ");
        string oldName = Console.ReadLine();

        LinkedListNode<string> node = studentList.Find(oldName);

        if (node != null)
        {
            Console.Write("Enter the new student name: ");
            string newName = Console.ReadLine();

            node.Value = newName;

            Console.WriteLine($"{oldName} updated to {newName}.");
        }
        else
        {
            Console.WriteLine($"{oldName} not found in the list.");
        }
    }

    public static void DeleteStudentByName(
        LinkedList<string> studentList)
    {
        Console.Write("Enter student name to delete: ");
        string name = Console.ReadLine();

        if (studentList.Remove(name))
        {
            Console.WriteLine($"{name} removed from the list.");
        }
        else
        {
            Console.WriteLine($"{name} not found in the list.");
        }
    }

    public static void ClearList(LinkedList<string> studentList)
    {
        studentList.Clear();

        Console.WriteLine("The list has been cleared.");
    }
}