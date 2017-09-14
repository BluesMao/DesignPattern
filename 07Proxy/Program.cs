using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07Proxy
{
    /// <summary>
    /// 代理模式（Proxy）：为其它对象提供一种代理以控制对这个对象的访问。
    /// </summary>

    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.Write("这是真实的请求！");
        }
    }

    class Proxy : Subject
    {
        private RealSubject realSubject;

        public override void Request()
        {
            if (this.realSubject == null)
            {
                this.realSubject = new RealSubject();
            }
            
            //此处可以附加一些业务
            Console.WriteLine("代理模式其实就是在访问对象时引入一定程度的间接性，可以附加多种用途");

            this.realSubject.Request();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = new Proxy();
            proxy.Request();

            Console.Read();
        }
    }
}
