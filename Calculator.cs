using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ06Exeptions
{
    internal class Calculator : ICalc
    {
        public event EventHandler<EventArgs> GotResult;
        private Stack<double> Results = new Stack<double>();
        
        private Stack<CalcActionLog> action = new Stack<CalcActionLog>();
        
        public double Result = 0;

        //Results.Push(0);
        
        public void Divide(double a)
        {
            if(a==0)
            {
                action.Push(new CalcActionLog(CalcAction.Divide, a));
                throw new CalculatorDivideByZeroException("Devide by zero is not allowed", action);
            }

            double min = Result / a;
            
            if (double.IsInfinity(min))
            {
                throw new CalculatorOperationCauseOverflowException("Operation cause overflow", action);
            }
            Results.Push(a);
            Result /= a;
            RayseEvent();
            
        }

        public void Multiply(double a)
        {
            double max = a * Result;
            if(double.IsInfinity(max))
            {
                action.Push(new CalcActionLog(CalcAction.Multiply, a));
                throw new CalculatorOperationCauseOverflowException("Operation cause overflow", action);
            }

            Results.Push(a);
            Result *= a;
            RayseEvent();
           

        }

        public void Substruct(double a)
        {
            double min = Result-a;
            if (double.IsInfinity(min))
            {
                action.Push(new CalcActionLog(CalcAction.Substruct, a));
                throw new CalculatorOperationCauseOverflowException("Operation cause overflow", action);
            }
            Results.Push(a);
            Result -= a;
            RayseEvent();
            

        }

        public void Sum(double a)
        {
            double max = a + Result;
            if (double.IsInfinity(max))
            {
                action.Push(new CalcActionLog(CalcAction.Sum, a));
                throw new CalculatorOperationCauseOverflowException("Operation cause overflow", action);
            }
            Results.Push(a);
            Result += a;
            RayseEvent();
            
        }


       private void RayseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }

        public void CancelLastOperation()
        {
            if (Results.Count == 1) 
            {
                Result = 0;
                Results.Clear();
            }
            
            if (Results.Count > 0)
            {
                Result = Results.Pop();
                RayseEvent();
            }
            
        }
    }
}
