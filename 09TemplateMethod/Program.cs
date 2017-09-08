using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09TemplateMethod
{
    abstract class AbstractClass
    {
        public abstract void PrimaryOperation1();
        public abstract void PrimaryOperation2();

        public void TemplateMethod()
        {
            PrimaryOperation1();
            PrimaryOperation2();

            Console.WriteLine("template method");
        }
    }

    class ConcreteClass1 : AbstractClass
    {
        public override void PrimaryOperation1()
        {
            Console.WriteLine("具体类C1对抽象类方法1的实现");
        }

        public override void PrimaryOperation2()
        {
            Console.WriteLine("具体类C1对抽象类方法2的实现");
        }
    }

    class ConcreteClass2 : AbstractClass
    {
        public override void PrimaryOperation1()
        {
            Console.WriteLine("具体类C2对抽象类方法1的实现");
        }

        public override void PrimaryOperation2()
        {
            Console.WriteLine("具体类C2对抽象类方法2的实现");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConcreteClass1 c1 = new ConcreteClass1();
            c1.TemplateMethod();

            ConcreteClass2 c2 = new ConcreteClass2();
            c2.TemplateMethod();


            Console.Read();
        }
    }
}
