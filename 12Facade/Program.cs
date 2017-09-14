using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12Facade
{
    /// <summary>
    /// 外观模式（Facade）：为子系统中的一组接口提供一个一致的界面，此模式定义了一个高层接口，这个接口使得这一子系统更加容易使用。
    /// </summary>

    class SubSystem1
    {
        public void Method1()
        {
            Console.WriteLine(this.GetType().Name + "：方法1");
        }
    }

    class SubSystem2
    {
        public void Method2()
        {
            Console.WriteLine(this.GetType().Name + "：方法2");
        }
    }

    class SubSystem3
    {
        public void Method3()
        {
            Console.WriteLine(this.GetType().Name + "：方法3");
        }
    }

    class SubSystem4
    {
        public void Method4()
        {
            Console.WriteLine(this.GetType().Name + "：方法4");
        }
    }

    class Facade
    {
        SubSystem1 ss1;
        SubSystem2 ss2;
        SubSystem3 ss3;
        SubSystem4 ss4;

        public Facade()
        {
            this.ss1 = new SubSystem1();
            this.ss2 = new SubSystem2();
            this.ss3 = new SubSystem3();
            this.ss4 = new SubSystem4();
        }

        public void Method1()
        {
            Console.WriteLine("方法组1：");
            this.ss1.Method1();
            this.ss2.Method2();
            this.ss3.Method3();
            this.ss4.Method4();
        }

        public void Method2()
        {
            Console.WriteLine("方法组2：");
            this.ss3.Method3();
            this.ss4.Method4();
            this.ss1.Method1();
            this.ss2.Method2();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Facade fc = new Facade();
            fc.Method1();

            fc.Method2();

            Console.Read();
        }
    }
}
