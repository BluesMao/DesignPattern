using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27ChainOfResponsibility
{
    /// <summary>
    /// 职责链模式（Chain Of Responsibility）：使多个对象都有机会处理请求，
    /// 从而避免请求的发送者和接收者之间的耦合关系。将这个对象连成一条链，并沿着这条链传递该请求，直到有一个对象处理它为止。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Hanlder h1 = new ConcreteHandler1();
            Hanlder h2 = new ConcreteHandler2();
            Hanlder h3 = new ConcreteHandler3();

            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }

            Console.Read();
        }
    }

    abstract class Hanlder
    {
        protected Hanlder successor;//继承者

        public void SetSuccessor(Hanlder successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    class ConcreteHandler1 : Hanlder
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} 处理请求 {1} ", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class ConcreteHandler2 : Hanlder
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} 处理请求 {1} ", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class ConcreteHandler3 : Hanlder
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} 处理请求 {1} ", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}
