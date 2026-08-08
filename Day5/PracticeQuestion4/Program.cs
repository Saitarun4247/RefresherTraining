using System;
using System.Collections.Generic;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Grade { get; set; }
}

public class StudentManager
{
    public Dictionary<int, Student> Students { get; set; }

    public StudentManager()
    {
        Students = new Dictionary<int, Student>();
    }

    public void AddStudent(Student student)
    {
        Students[student.Id] = student;
    }

    public void DisplayStudents()
    {
        Console.WriteLine("Student Information:");

        foreach (var student in Students.Values)
        {
            Console.WriteLine(
                $"ID: {student.Id}, Name: {student.Name}, Grade: {student.Grade}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        StudentManager manager = new StudentManager();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            int id = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            string grade = Console.ReadLine();

            Student student = new Student
            {
                Id = id,
                Name = name,
                Grade = grade
            };

            manager.AddStudent(student);
        }

        manager.DisplayStudents();
    }
}