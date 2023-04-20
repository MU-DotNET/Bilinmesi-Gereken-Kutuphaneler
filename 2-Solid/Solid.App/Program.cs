
using Solid.App.OpenClosed;

SalaryCalculator salaryCalculator = new();
Console.WriteLine($"Low Salary : { salaryCalculator.Calculate(1000, SalaryType.Low)}");
Console.WriteLine($"Medium Salary : { salaryCalculator.Calculate(1000, SalaryType.Medium)}");
Console.WriteLine($"High Salary : { salaryCalculator.Calculate(1000, SalaryType.High)}");