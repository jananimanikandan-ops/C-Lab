using System;

class Student
{
    int rollNo;
    string name="";
    float marks;

    public void GetData()
    {
        Console.Write("Enter Roll Number: ");
        rollNo = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Student Name: ");
        name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        marks = Convert.ToSingle(Console.ReadLine());
    }

    public void DisplayData()
    {
        Console.WriteLine("\n----- Student Details -----");
        Console.WriteLine("Roll Number : " + rollNo);
        Console.WriteLine("Student Name: " + name);
        Console.WriteLine("Marks       : " + marks);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student s = new Student();

        s.GetData();
        s.DisplayData();

        Console.ReadKey();
    }
}
