using System;

//-------------------- Interface --------------------
interface IExport
{
    void Export();
}

//-------------------- Abstract Class --------------------
abstract class Report : IExport
{
    public string Title { get; set; }

    public abstract void Generate();

    public void Export()
    {
        Console.WriteLine("Report Exported Successfully");
    }
}

//-------------------- PDF Report --------------------
class PDFReport : Report
{
    public override void Generate()
    {
        Console.WriteLine("Generating PDF Report");
    }
}

//-------------------- Excel Report --------------------
class ExcelReport : Report
{
    public override void Generate()
    {
        Console.WriteLine("Generating Excel Report");
    }
}

//-------------------- CSV Report --------------------
class CSVReport : Report
{
    public override void Generate()
    {
        Console.WriteLine("Generating CSV Report");
    }
}

//-------------------- Factory Pattern --------------------
class ReportFactory
{
    public static Report Create(string type)
    {
        switch (type.ToUpper())
        {
            case "PDF":
                return new PDFReport();

            case "EXCEL":
                return new ExcelReport();

            case "CSV":
                return new CSVReport();

            default:
                return null;
        }
    }
}

//-------------------- Extension Method --------------------
static class ReportExtension
{
    public static string FormatTitle(this string title)
    {
        return "*** " + title.ToUpper() + " ***";
    }
}

//-------------------- Main Program --------------------
class Program
{
    static void Main()
    {
        // Factory Pattern
        Report report = ReportFactory.Create("PDF");

        report.Title = "Monthly Sales Report";

        Console.WriteLine(report.Title.FormatTitle());

        report.Generate();

        report.Export();

        Console.WriteLine();

        // Anonymous Type
        var row = new
        {
            Id = 101,
            Name = "Laptop",
            Amount = 50000
        };

        Console.WriteLine("Anonymous Report Row");
        Console.WriteLine(row.Id);
        Console.WriteLine(row.Name);
        Console.WriteLine(row.Amount);
    }
}