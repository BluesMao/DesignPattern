using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _15AbstractFactory
{
    /// <summary>
    /// 抽象工厂模式（Abstract Factory）：提供一个创建一系列相关或相互依赖对象的接口，而无需指定它们具体的类。
    /// </summary>

    public class User
    {
        public int id { get; set; }

        public string name { get; set; }
    }

    public interface IUser
    {
        void Insert(User user);
        User GetUser(int id);
    }

    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public interface IDpartment
    {
        void Insert(Department department);
        Department GetDepartment(int id);
    }

    class SqlserverUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在SQL Server 中给User表增加一条记录");
        }

        public User GetUser(int id)
        {
            Console.WriteLine("在Sql Server 中根据ID得到一个User对象");
            return null;
        }
    }

    class AccessUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Access 中给User表增加一条记录");
        }

        public User GetUser(int id)
        {
            Console.WriteLine("在Access 中根据ID得到一个User对象");
            return null;
        }
    }

    interface IFactory
    {
        IUser CreateUser();
    }

    class SqlServerFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new SqlserverUser();
        }
    }

    class AccessFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new AccessUser();
        }
    }


    class DataAccess
    {
        private static readonly string AssemblyName = "15AbstractFactory";
        private static readonly string db = System.Configuration.ConfigurationManager.AppSettings["DB"];

        public static IUser CreateUser()
        {
            string className = AssemblyName + "." + db + "User";
            return (IUser)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IDpartment CreateDepartment()
        {
            string className = AssemblyName + "." + db + "Department";
            return (IDpartment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            IFactory factory = new SqlServerFactory();

            IUser iu = factory.CreateUser();

            iu.Insert(user);
            iu.GetUser(1);

            /////////////////////////////////
            DataAccess.CreateUser();
            DataAccess.CreateDepartment();


            Console.Read();
        }
    }
}
