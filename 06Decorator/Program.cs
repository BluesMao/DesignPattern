using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Decorator
{
    class Person
    {
        private string name;

        public Person() { }

        public Person(string name)
        {
            this.name = name;
        }

        public virtual void Show()
        {
            Console.WriteLine("装扮的{0}", name);
        }
    }

    class Finery : Person
    {
        private Person person;

        public Finery()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
