namespace DZ06Exeptions
{
    internal class Program
    {
        // Спроектируем интерфейс калкулятора, поддерживающего простые арифметические операции, хранящего результат и способного выводить информацию 
        // о результате при помощи события

        // задача дополнителльная, арифметические действия как обычно выполняются, только можно будет отменять последнее действие, вплоть до начала.

        //static void Calculator_GotResult(object sendler, EventArgs eventArgs)
        //{
        //    Console.WriteLine($"{((Calculator)sendler).Result}");
        //}


        //Exeptions - исключения надо доработать калькулятор, 
        // Использовать исключения для обработки ошибок в калькуляторе, 
        // например деление на ноль, ввод не числовых данных и т.д.
        // реализовать свои типы исключений, CalculatorDivideByZeroException, CalculatorOperationCauseOverflowException, CalculatorInputDataFormatException

        static void Calculator_GotResultTwo(object sendler, EventArgs eventArgs)
        {
            Console.WriteLine($" result = {((Calculator)sendler).Result}");
        }

        static void Execute(Action<double> action, double value = 10)
        {
            try
            {
                action.Invoke(value);

            }
            catch (CalculatorDivideByZeroException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.ToString());
            }
            catch (CalculatorOperationCauseOverflowException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.ToString());
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


        static void Main(string[] args)
        {
           ICalc calc = new Calculator();
           //calc.GotResult += Calculator_GotResult;
           calc.GotResult += Calculator_GotResultTwo;

            Execute(calc.Sum, double.MaxValue);
            Execute(calc.Sum, double.MaxValue);
            Execute(calc.Divide, 0);
            Execute(calc.Multiply, double.MaxValue);
            Execute(calc.Substruct, double.MinValue);
            Execute(calc.Substruct, double.MaxValue);



            //Доработайте программу калькулятор реализовав выбор действий и вывод результатов на 
            //экран в цикле так чтобы калькулятор мог работать до тех пор пока пользователь не нажмет
            //отмена или введёт пустую строку
            /*
            while (true)
            {
                Console.WriteLine("Enter the first number please, and confirm");
                string input1 = Console.ReadLine();
                if (string.IsNullOrEmpty(input1))
                {
                    break;
                }
                double number1 = double.Parse(input1);

                calc.Sum(number1);

                while (true)
                {
                    Console.WriteLine("Enter * ,/ ,+ ,-, cancel, and confirm");
                    string action = Console.ReadLine();
                    if (string.IsNullOrEmpty(action))
                    {
                        break;
                    }
                    if (action == "cancel")
                    {
                        calc.CancelLastOperation();
                        continue;
                    }



                    Console.WriteLine("Enter second number please and confirm");
                    string input2 = Console.ReadLine();
                    if (string.IsNullOrEmpty(input2))
                    {
                        break;
                    }
                    double number2 = double.Parse(input2);

                    switch (action)
                    {
                        case "*":
                            calc.Multiply(number2);
                            break;
                        case "/":
                            calc.Divide(number2);
                            break;
                        case "+":
                            calc.Sum(number2);
                            break;
                        case "-":
                            calc.Substruct(number2);
                            break;
                        
                    }
                    
                }

                Console.WriteLine("The end");
                break;

                
            }
            */



            Console.WriteLine("The end");
        }

    }
}
