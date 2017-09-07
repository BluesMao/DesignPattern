using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimpleFactory
{
    public class Operation
    {
        public double numberA { get; set; }

        public double numberB { get; set; }

        public virtual double GetResult()
        {
            return 0;
        }
    }

    public class OperationAdd : Operation
    {
        public override double GetResult()
        {
            return numberA + numberB;
        }
    }

    public class OperationMinus : Operation
    {
        public override double GetResult()
        {
            return numberA - numberB;
        }
    }

    public class OperationMultiply : Operation
    {
        public override double GetResult()
        {
            return numberA * numberB;
        }
    }

    public class OperationDivide : Operation
    {
        public override double GetResult()
        {
            if (numberB == 0)
            {
                throw new Exception("除数不能为0");
            }
            return numberA / numberB;
        }
    }

    public class OperationFactory
    {
        public static Operation CreateOperation(string symbol)
        {
            Operation oper = null;
            switch (symbol)
            {
                case "+":
                    {
                        oper = new OperationAdd();
                        break;
                    }
                case "-":
                    {
                        oper = new OperationMinus();
                        break;
                    }
                case "*":
                    {
                        oper = new OperationMultiply();
                        break;
                    }
                case "/":
                    {
                        oper = new OperationDivide();
                        break;
                    }
            }
            return oper;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("请输入数字A：");
                string strNumberA = Console.ReadLine();
                Console.Write("请选择运算符号(+、-、*、/)：");
                string strOperate = Console.ReadLine();
                Console.Write("请输入数字B：");
                string strNumberB = Console.ReadLine();
                string strResult = "";

                Operation oper;
                oper = OperationFactory.CreateOperation(strOperate);
                oper.numberA = Convert.ToDouble(strNumberA);
                oper.numberB = Convert.ToDouble(strNumberB);
                strResult = oper.GetResult().ToString();

                Console.WriteLine("结果是：" + strResult);

                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine("您的输入有错：" + ex.Message);
            }
        }
    }
}
