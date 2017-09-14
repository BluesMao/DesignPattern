using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08FactoryMethod
{
    /// <summary>
    /// 工厂方法模式（Factory Method）：定义一个用于创建对象的接口，让子类决定实例化哪一个类。
    /// 工厂方法使一个类的实例化延迟到其子类。
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            IFactory operFactory = new AddFactory();
            Operation oper = operFactory.CreateOperation();

            oper.numberA = 1;
            oper.numberB = 2;

            double result = oper.GetResult();
            Console.WriteLine(result);

            Console.Read();
        }
    }

    interface IFactory
    {
        Operation CreateOperation();
    }

    class AddFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationAdd();
        }
    }

    class SubFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationMinus();
        }
    }

    class MulFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationMultiply();
        }
    }

    class DivFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationDivide();
        }
    }

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
}
