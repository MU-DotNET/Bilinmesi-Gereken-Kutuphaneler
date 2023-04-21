#region OpenClosed Principle

using Solid.App.OpenClosed.Bad;
using p = Solid.App.OpenClosed.Good;
using Solid.App.OpenClosed.BestPractice;
using Solid.App.LiskovSubstition.Bad;

//Solid.App.OpenClosed.Good.SalaryCalculator salaryCalculatorGood = new();
//Solid.App.OpenClosed.BestPractice.SalaryCalculator salaryCalculatorBestPractice = new();

//Bad Way
//Console.WriteLine($"Low Salary : { salaryCalculator.Calculate(1000, SalaryType.Low)}");
//Console.WriteLine($"Medium Salary : { salaryCalculator.Calculate(1000, SalaryType.Medium)}");
//Console.WriteLine($"High Salary : { salaryCalculator.Calculate(1000, SalaryType.High)}");

////Good Way
//Console.WriteLine($"Low Salary : {salaryCalculatorGood.Calculate(1000,new LowSalaryCalculate())}");
//Console.WriteLine($"Medium Salary : {salaryCalculatorGood.Calculate(1000, new MediumSalaryCalculate())}");
//Console.WriteLine($"High Salary : {salaryCalculatorGood.Calculate(1000, new HighSalaryCalculate())}");
//Console.WriteLine($"Manager Salary : {salaryCalculatorGood.Calculate(1000, new ManagerSalaryCalculate())}");

//Best Practice Way
//Console.WriteLine($"Low Salary : {salaryCalculatorBestPractice.Calculate(1000, new LowSalaryCalculate().Calculate)}");
//Console.WriteLine($"Medium Salary : {salaryCalculatorBestPractice.Calculate(1000, new MediumSalaryCalculate().Calculate)}");
//Console.WriteLine($"High Salary : {salaryCalculatorBestPractice.Calculate(1000, new HighSalaryCalculate().Calculate)}");
//Console.WriteLine($"Manager Salary : {salaryCalculatorBestPractice.Calculate(1000, new ManagerSalaryCalculate().Calculate)}");

//Console.WriteLine($"Custom Salary : {salaryCalculatorBestPractice.Calculate(1000, x =>
//{
//    return x * 10;
//})}");
#endregion
#region Liskov Substition Principle
//BasePhone phone = new Iphone();

//phone.Call();
//phone.TakePhoto();

//phone = new Nokia3310();

//phone.Call();
//phone.TakePhoto();
BasePhone phone;
int i = 1;

if (i == 1)
{
    phone = new IPhone();
    phone.Call();
    phone.TakePhoto();
}
else
{
    phone = new Nokia3310();
    phone.Call();
    phone.TakePhoto();
}


#endregion