using System;
using System.Collections.Generic;

namespace Visitor
{
    class Program
    {
        static void Main()
        {
            IVisitable kolyan = new Kolyan { Balance = 5000 };
            var visitors = new List<IVisitor> {new Police(), new Collectors()};
            foreach (var visitor in visitors)
            {
                kolyan.Accept(visitor);
            }
            Console.WriteLine("Итого у Коляна осталось {0}", kolyan.Balance);

            Console.ReadKey();
        }
    }

    public interface IVisitor
    {
        void Visit(IVisitable target);
    }

    public interface IVisitable
    {
        int Balance { get; set; }
        void Accept(IVisitor visitor);
    }

    public class Police : IVisitor
    {
        public void Visit(IVisitable target)
        {
            target.Balance -= 1000;
            Console.WriteLine("После ГИБДД у Коляна осталось {0} рублей", target.Balance);
        }
    }

    public class Collectors : IVisitor
    {
        public void Visit(IVisitable target)
        {
            target.Balance -= 2000;
            Console.WriteLine("После коллекторов у Коляна осталось {0} рублей", target.Balance);
        }
    }

    public class Kolyan : IVisitable
    {
        public int Balance { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
