using System;
using System.Collections.Generic;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }

    public Student(string name, int age, int marks)
    {
        Name = name;
        Age = age;
        Marks = marks;
    }
}

class StudentComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        // 1. Highest Marks first
        if (x.Marks != y.Marks)
        {
            return y.Marks.CompareTo(x.Marks);
        }

        // 2. If marks are equal, youngest age first
        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("John", 22, 85),
            new Student("Alice", 20, 95),
            new Student("Bob", 19, 85),
            new Student("David", 21, 95)
        };

        students.Sort(new StudentComparer());

        foreach (Student student in students)
        {
            Console.WriteLine(
                $"{student.Name} {student.Age} {student.Marks}"
            );
        }
    }
}