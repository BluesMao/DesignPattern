using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25Mediator
{
    /// <summary>
    /// 中介者模式（Mediator）：用一个中介对象来封装一系列的对象交互。
    /// 中介者使各对象不需要显示地相互引用，从而使其耦合松散，而且可以独立地改变它们之间的交互。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteMediator m = new ConcreteMediator();

            //使两个具体同事类认识中介对象
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);

            //让中介者认识各个具体同事类对象
            m.Colleague1 = c1;
            m.Colleague2 = c2;

            //具体同事类对象的发送信息都是通过中介者转发的
            c1.Send("吃过饭了嘛？");
            c1.Send("没有呢，你打算请客？");

            Console.Read();
        }
    }

    //抽象中介者，定义了同事对象到中介者对象的接口
    abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    //具体中介者对象，实现抽象类的方法，它需要知道所有具体同事类，并从具体同事接收消息，向具体同事对象发出命令
    class ConcreteMediator : Mediator
    {
        //需要知道所有的具体同事对象
        private ConcreteColleague1 colleague1;
        private ConcreteColleague2 colleague2;

        public ConcreteColleague1 Colleague1
        {
            set { colleague1 = value; }
        }

        public ConcreteColleague2 Colleague2
        {
            set { colleague2 = value; }
        }

        public override void Send(string message, Colleague colleague)
        {
            if (colleague == colleague1)
            {
                colleague1.Nofity(message);
            }
            else
            {
                colleague2.Nofity(message);
            }
        }
    }

    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator)
            : base(mediator)
        {

        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Nofity(string message)
        {
            Console.WriteLine("同事 1 得到信息：" + message);
        }
    }

    class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator)
            : base(mediator)
        {

        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Nofity(string message)
        {
            Console.WriteLine("同事 2 得到信息：" + message);
        }
    }
}
