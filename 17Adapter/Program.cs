using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17Adapter
{
    /// <summary>
    /// 适配器模式（Adapter）：将一个类的接口转换成客户希望的另外一个接口。
    /// Adapter模式使得由于接口不兼容而不能一起工作的那些类可以一起工作。
    /// </summary>

    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("普通请求！");
        }
    }

    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("特殊请求！");
        }
    }

    class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Target target = new Adapter();
            target.Request();

            Console.Read();
        }
    }
}
