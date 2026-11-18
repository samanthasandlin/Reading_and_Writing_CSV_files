
using System;
using System.IO;
using System.Linq;

string filePath = "../../../small_csv.csv";

// STEP 1: Add Andrew Burton to the CSV file
string newEmployee = "106,Andrew Burton,Marketing,100000,2025-04-21";

// Check if Andrew is already in the file
string[] existingLines = File.ReadAllLines(filePath);

if (!existingLines.Any(line => line.StartsWith("106,")))
{
    File.AppendAllText(filePath, newEmployee + Environment.NewLine);
}

// STEP 2: Read and display ALL five columns
string[] lines = File.ReadAllLines(filePath);

Console.WriteLine("ALL EMPLOYEES:");

foreach (string line in lines.Skip(1))
{
    string[] columns = line.Split(",");

    string empid = columns[0];
    string name = columns[1];
    string department = columns[2];
    double salary = double.Parse(columns[3]);
    string joiningDate = columns[4];

    Console.WriteLine($"ID: {empid}, Name: {name}, Department: {department}, Salary: {salary:C2}, Joining Date: {joiningDate}");
}

// STEP 3: Set up salary totals and counts
double EngSalary = 0.0;
int EngCount = 0;

double MarketingSalary = 0.0;
int MarketingCount = 0;

double TotalSalary = 0.0;
int TotalCount = 0;

// STEP 4: Read each employee and calculate totals
using (StreamReader reader = new StreamReader(filePath))
{
    string? header = reader.ReadLine();
    string? line;

    while ((line = reader.ReadLine()) != null)
    {
        string[] cols = line.Split(",");

        string empyname = cols[1];
        string dept = cols[2];
        double salary = double.Parse(cols[3]);

        // Engineering department
        if (dept == "Engineering")
        {
            EngSalary += salary;
            EngCount++;
        }

        // Marketing department
        if (dept == "Marketing")
        {
            MarketingSalary += salary;
            MarketingCount++;
        }

        // All employees
        TotalSalary += salary;
        TotalCount++;
    }
}

// STEP 5: Calculate and display averages
Console.WriteLine("\nAVERAGE SALARIES:");

if (EngCount > 0)
{
    Console.WriteLine($"Engineering Average: {EngSalary / EngCount:C2}");
}

if (MarketingCount > 0)
{
    Console.WriteLine($"Marketing Average: {MarketingSalary / MarketingCount:C2}");
}

if (TotalCount > 0)
{
    Console.WriteLine($"Organization Average: {TotalSalary / TotalCount:C2}");
}
