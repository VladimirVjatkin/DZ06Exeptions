using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ06Exeptions
{
    internal interface ICalc
    {
        event EventHandler<EventArgs> GotResult;

        public void Sum(double a);
        public void Substruct(double a);
        public void Multiply(double a);
        public void Divide(double a);

        public void CancelLastOperation();

    }
}
