namespace Solid.App.OpenClosed.BestPractice
{
    public interface ISalaryCalculate
    {
        decimal Calculate(decimal salary);
    }
    public class LowSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 2;
        }
    }
    public class MediumSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 4;
        }
    }
    public class HighSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 6;
        }
    }
    public class ManagerSalaryCalculate : ISalaryCalculate
    {
        public decimal Calculate(decimal salary)
        {
            return salary * 7;
        }
    }
    public class SalaryCalculator
    {
        //Action => void : Parametre alan geriye void dönen
        //Predicate => bool : Parametre alan geriye bool dönen
        //Function => : Herhangi bir Parametre alan ve geriye herhangi bir tip/tür dönen
        public decimal Calculate(decimal salary, Func<decimal,decimal> calculateDelegate)
        {
            return calculateDelegate(salary);
        }
    }
}
