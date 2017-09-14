using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14Observer
{
    /// <summary>
    /// 观察者模式（Observer）：定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个主题对象。
    /// 这个主题对象在状态发生变化时，会通知所有观察者对象，使它们能够自动更新自己。
    /// </summary>

    abstract class Subject
    {
        private IList<Observer> observers = new List<Observer>();

        //增加观察者
        public void Attach(Observer observer)
        {
            this.observers.Add(observer);
        }

        //减少观察者
        public void Detach (Observer observer)
        {
            this.observers.Remove(observer);
        }

        //通知
        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class ConcreteSubject : Subject
    {
        private string subjectState;

        public string SubjectState
        {
            get { return subjectState; }
            set { subjectState = value; }
        }
    }

    class ConcreteObserver : Observer
    {
        private string name;
        private string observerState;
        private ConcreteSubject subject;

        public ConcreteObserver(string name, ConcreteSubject subject)
        {
            this.name = name;
            this.subject = subject;
        }

        public override void Update()
        {
            observerState = subject.SubjectState;
            Console.WriteLine("观察者{0}的新状态是{1}",name,observerState);
        }

        public ConcreteSubject Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject s = new ConcreteSubject();

            s.Attach(new ConcreteObserver("A", s));
            s.Attach(new ConcreteObserver("B", s));

            s.SubjectState = "ABC";
            s.Notify();

            Console.Read();
        }
    }
}
