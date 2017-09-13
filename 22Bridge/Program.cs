using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22Bridge
{
    /// <summary>
    /// 合成/聚合利用原则 (CARP): 尽量使用合成/聚合，尽量不要使用继承。
    /// 
    /// 桥接模式（Bridge）：将抽象部分与它的实现部分分离，使它们都可以独立地变化。
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Abstraction ab = new RefinedAbstraction();

            ab.SetImplementor(new ConcreteImplementorA());
            ab.Operation();

            ab.SetImplementor(new ConcreteImplementorB());
            ab.Operation();

            Console.Read();
        }
    }

    abstract class Implementor
    {
        public abstract void Operation();
    }

    class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现A的方法执行");
        }
    }

    class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现B的方法执行");
        }
    }

    class Abstraction
    {
        protected Implementor implementor;

        public void SetImplementor (Implementor implementor)
        {
            this.implementor = implementor;
        }

        public virtual void Operation()
        {
            this.implementor.Operation();
        }
    }

    class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            implementor.Operation();
        }
    }
}
