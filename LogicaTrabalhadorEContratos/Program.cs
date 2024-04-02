// See https://aka.ms/new-console-template for more information
using LogicaTrabalhadorEContratos.Entities.Enums;
using LogicaTrabalhadorEContratos.Entities;
using System.Globalization;

Console.WriteLine("Hello, World!");



Console.WriteLine("Hello, Isabella!");

Console.Write("Enter department's name: ");
var departmentName = Console.ReadLine();

Console.WriteLine("Enter worker data: ");
Console.Write("Name: ");
var name = Console.ReadLine();

Console.Write("Level (Junior/MidLevel/Senior): ");
var level = Enum.Parse<WorkerLevel>(Console.ReadLine());

Console.Write("Base salary: ");
var baseSalary = double.Parse(Console.ReadLine());

var department = new Department(departmentName);
var worker = new Worker(name, level, baseSalary, department);

Console.Write("How many contracts to this worker? ");
var quantityContracts = int.Parse(Console.ReadLine());

for (var i = 1; i <= quantityContracts; i++)
{
    Console.WriteLine($"Enter #{i} contract data:");
    Console.Write("Date (DD/MM/YYYY): ");
    var date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

    Console.Write("Value per hour: ");
    var valuePerHour = double.Parse(Console.ReadLine());

    Console.Write("Duration (hour): ");
    var duration = int.Parse(Console.ReadLine());

    var hourContract = new HourContract(date, valuePerHour, duration);

    worker.AddContract(hourContract);
}

Console.Write("Enter month and year to calculate income (MM/YYYY): ");
var dateCalculateIncomeMonthAndYear = Console.ReadLine();


var month = int.Parse(dateCalculateIncomeMonthAndYear.Substring(0, 2));

var year = int.Parse(dateCalculateIncomeMonthAndYear.Substring(3));
var valueIncome = worker.Income(year, month);

Console.WriteLine($"Name: {worker.Name} ");
Console.WriteLine($"Department: {worker.Department.Name} ");
Console.WriteLine($"Income for {dateCalculateIncomeMonthAndYear}: {valueIncome.ToString("F2", CultureInfo.InvariantCulture)}");