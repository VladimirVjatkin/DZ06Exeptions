using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ06Exeptions
{
    internal class CalcActionLog
    {

        public CalcAction CalcAction { get; private set; }
        public double CalcArgument { get; private set; }
        public CalcActionLog(CalcAction calcAction, double calcArgument)
        {
            CalcAction = calcAction;
            CalcArgument = calcArgument;
        }
    }
}
