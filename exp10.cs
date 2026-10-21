using System;
using System.Data;

class Program
{
    static void Main()
    {
        
        DataSet ds = new DataSet("CollegeDB");
        DataTable studentTable = new DataTable("Student");

        
        studentTable.Columns.Add("Id", typeof(int));
        studentTable.Columns.Add("Name", typeof(string));
        studentTable.Columns.Add("Department", typeof(string));

        
        studentTable.Rows.Add(1, "Abdul", "IT");
        studentTable.Rows.Add(2, "Chandru", "CSE");
        studentTable.Rows.Add(3, "Reshma", "ECE");

        
        ds.Tables.Add(studentTable);

        Console.WriteLine("--- Student Details (Disconnected Memory Mode) ---");

        
        foreach (DataRow row in studentTable.Rows)
        {
            Console.WriteLine($"ID: {row["Id"]} | Name: {row["Name"]} | Dept: {row["Department"]}");
        }
    }
}