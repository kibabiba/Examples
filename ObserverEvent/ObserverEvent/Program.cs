using System;
using System.Collections.Generic;

namespace ObserverEvent
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        static void Main()
        {
            //использование С# -обзервера
            var subjectEvent = new SubjectEvent();
            subjectEvent.AddObserver(new ShowBalanceObserver());
            subjectEvent.AddObserver(new ShowNameObserver());
            subjectEvent.Notify();

            //Использование классического обзервера
            var subjectClassic = new SubjectClassic();
            subjectClassic.AddObserver(new ShowBalanceObserver());
            subjectClassic.AddObserver(new ShowNameObserver());
            subjectClassic.Notify();
        }
    }

    public abstract class Subject
    {
        public const string Name = "Ololo";
        public const int Balance = 10;
    }

    public class SubjectEvent : Subject //Реализация обзервера на эвентах C#
    {
        private delegate void MyDelegete(Subject subject);
        private event MyDelegete MyEvent;

        public void AddObserver(IObserver observer)
        {
            MyEvent += observer.DoSomething;
        }

        public void Notify()
        {
            MyEvent(this);
        }
    }

    public class SubjectClassic : Subject //Классический обзервер, как на всех языках
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.DoSomething(this);
            }
        }
    }

    //---------------------Сами обзерверы-------------------------

    public interface IObserver
    {
        void DoSomething(Subject subject);
    }

    public class ShowNameObserver : IObserver
    {
        public void DoSomething(Subject subject)
        {
            Console.WriteLine(Subject.Name);
        }
    }

    public class ShowBalanceObserver : IObserver
    {
        public void DoSomething(Subject subject)
        {
            Console.WriteLine(Subject.Balance);
        }
    }
}