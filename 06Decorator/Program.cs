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

        public Person()
        {

        }

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
        protected Person component;

        public Finery()
        {
        }

        public void Decorate(Person component)
        {
            this.component = component;
        }

        public override void Show()
        {
            if (this.component != null)
            {
                component.Show();
            }
        }
    }

    class TShirts : Finery
    {
        public TShirts()
        {

        }

        public override void Show()
        {
            Console.Write("大T恤 ");
            base.Show();
        }
    }

    class BigTrouser : Finery
    {
        public BigTrouser()
        {

        }
        public override void Show()
        {
            Console.Write("垮裤 ");
            base.Show();
        }
    }

    class Sneakers : Finery
    {
        public Sneakers()
        {

        }
        public override void Show()
        {
            Console.Write("破球鞋 ");
            base.Show();
        }
    }

    class Suit : Finery
    {
        public Suit()
        {

        }
        public override void Show()
        {
            Console.Write("西装 ");
            base.Show();
        }
    }

    class Tie : Finery
    {
        public Tie()
        {

        }
        public override void Show()
        {
            Console.Write("领带 ");
            base.Show();
        }
    }

    class LeatherShoes : Finery
    {
        public LeatherShoes()
        {

        }
        public override void Show()
        {
            Console.Write("皮鞋 ");
            base.Show();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("小新");

            Console.WriteLine("第一种装扮：");

            Sneakers sk = new Sneakers();
            BigTrouser bt = new BigTrouser();
            TShirts ts = new TShirts();

            sk.Decorate(person);
            bt.Decorate(sk);
            ts.Decorate(bt);

            ts.Show();

            Console.WriteLine("第二种装扮：");

            LeatherShoes ls = new LeatherShoes();
            Tie tie = new Tie();
            Suit suit = new Suit();
            ls.Decorate(person);
            tie.Decorate(ls);
            suit.Decorate(tie);

            suit.Show();

            Console.Read();
        }
    }
}
