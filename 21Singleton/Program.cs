using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Singleton
{
    /// <summary>
    /// 单例模式（Singleton）：保证一个类仅有一个实例，并提供一个访问它的全局访问点。
    /// </summary>
    class Singleton
    {
        private static Singleton instance;

        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("两个对象是相同的实例。");
            }

            Console.Read();
        }
    }
}
