using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13Builder
{
    class Product
    {
        IList<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\n产品创建-------");
            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    abstract class Builder
    {
        public abstract void BuilderPartA();

        public abstract void BuilderPartB();

        public abstract Product GetResult();
    }

    class ConcreteBuilderA : Builder
    {
        Product product = new Product();

        public override void BuilderPartA()
        {
            Console.WriteLine("部件A");
        }

        public override void BuilderPartB()
        {
            Console.WriteLine("部件B");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    class ConcreteBuilderB : Builder
    {
        Product product = new Product();

        public override void BuilderPartA()
        {
            Console.WriteLine("部件X");
        }

        public override void BuilderPartB()
        {
            Console.WriteLine("部件Y");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuilderPartA();
            builder.BuilderPartB();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();

            Builder b1 = new ConcreteBuilderA();
            Builder b2 = new ConcreteBuilderB();

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();


            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();

            Console.Read();
        }
    }
}
