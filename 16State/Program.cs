using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16State
{
    /// <summary>
    /// 状态模式（State）：当一个对象的内在状态在状态改变时允许改变其行为，这个对象看起来像是改变了其类。
    /// </summary>

    abstract class State
    {
        public abstract void Handle(Context context);
    }

    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }

    class Context
    {
        private State state;

        public Context (State state)
        {
            this.state = state;
        }

        public State State
        {
            get { return this.state; }
            set
            {
                this.state = value;
                Console.WriteLine("当前状态：" + this.state.GetType().Name);
            }
        }

        public void Request()
        {
            state.Handle(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new ConcreteStateA());

            context.Request();
            context.Request();
            context.Request();
            context.Request();

            Console.Read();
        }
    }
}
