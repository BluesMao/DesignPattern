using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18Memento
{
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
