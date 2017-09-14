using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18Memento
{
    /// <summary>
    /// 备忘录模式（Memento）：在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。
    /// 这样以后就可将该对象恢复到原先保存的状态。
    /// </summary>

    class Originator
    {
        private string state;
        public string State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public Memento CreateMemento()
        {
            return new Memento(state);
        }

        public void SetMemento(Memento memento)
        {
            this.state = memento.State;
        }

        public void Show()
        {
            Console.WriteLine("State:" + this.state);
        }
    }

    //负责存储 Originator 对象的内部状态，并可防止 Originator 以外的对象访问备忘录 Memento
    class Memento
    {
        private string state;
        public Memento(string state)
        {
            this.state = state;
        }

        public string State
        {
            get
            {
                return this.state;
            }
        }
    }

    class Caretaker
    {
        private Memento memento;

        public Memento Memento
        {
            get { return this.memento; }
            set { this.memento = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();
            originator.State = "On";
            originator.Show();

            Caretaker caretaker = new Caretaker();
            caretaker.Memento = originator.CreateMemento();

            originator.State = "Off";
            originator.Show();

            originator.SetMemento(caretaker.Memento);
            originator.Show();

            Console.Read();
        }
    }
}
