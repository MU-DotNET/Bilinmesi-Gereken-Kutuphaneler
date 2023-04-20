namespace Solid.App.OpenClosed
{
    public class SalaryCalculator
    {
        public decimal Calculate(decimal salary, SalaryType salaryType)
        {
            decimal newSalary = 0;

            switch (salaryType)
            {
                case SalaryType.Low:
                    newSalary = salary * 2;
                    break;
                case SalaryType.Medium:
                    newSalary = salary * 4;
                    break;
                case SalaryType.High:
                    newSalary = salary * 6;
                    break;
                default:
                    break;
            }
            return newSalary;
        }
    }

    public enum SalaryType
    {
        Low,
        Medium,
        High
    }
}
