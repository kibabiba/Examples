using System;
using System.Collections.Generic;

namespace Visitor
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        static void Main()
        {
            var kolyan = new Kolyan { Balance = 5000 };
            var visitors = new List<IVisitor> {new Police(), new Collectors()};
            foreach (var visitor in visitors)
            {
                kolyan.Accept(visitor);
            }
            Console.WriteLine($"Итого у Коляна осталось {kolyan.Balance}");

            Console.ReadKey();
        }
    }

    public interface IVisitor
    {
        void Visit(IVisitable target);
    }

    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }

    public interface IPerson
    {
        int Balance { get; set; }
    }

    public class Police : IVisitor
    {
        public void Visit(IVisitable target)
        {
            var balance = ((IPerson)target).Balance -= 2000;
            Console.WriteLine($"После ГИБДД у Коляна осталось {balance} рублей");
        }
    }

    public class Collectors : IVisitor
    {
        public void Visit(IVisitable target)
        {
            var balance = ((IPerson)target).Balance -= 1000;
            Console.WriteLine($"После коллекторов у Коляна осталось {balance} рублей");
        }
    }

    public class Kolyan : IVisitable, IPerson
    {
        public int Balance { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
