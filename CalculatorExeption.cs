using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ06Exeptions 
{
    internal class CalculatorExeption : Exception
    {
        public CalculatorExeption(string message, Stack<CalcActionLog> actionLogs) : base(message)
        {
            ActionLogs = actionLogs;
        }

        public CalculatorExeption(string v, Exception e) : base(v, e)
        {

        }

        public override string ToString()
        {
            return Message + ": " + string.Join("\n", ActionLogs.Select(x=> $"{x.CalcAction} {x.CalcArgument}"));
        }

        public Stack<CalcActionLog> ActionLogs { get; private set; }



    }

    internal class CalculatorDivideByZeroException : CalculatorExeption
    {
        

        public CalculatorDivideByZeroException(string v, Stack<CalcActionLog> actionLogs) : base(v, actionLogs)
        {
            
        }
        public CalculatorDivideByZeroException(string v, Exception e) : base(v, e)
        {

        }

        

    }
    internal class CalculatorOperationCauseOverflowException : CalculatorExeption
    {
        public CalculatorOperationCauseOverflowException(string message, Stack<CalcActionLog> actionLogs) : base(message, actionLogs)
        {

        }

        public CalculatorOperationCauseOverflowException(string v, Exception e) : base(v, e)
        {

        }
     }

}
