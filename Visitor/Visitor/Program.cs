using System;
using System.Collections.Generic;

namespace Visitor
{
    class Program
    {
        static void Main()
        {
            var kolyan = new Kolyan { Balance = 5000 };
            var visitors = new List<IVisitor<IPerson>> {new Police(), new Collectors()};
            foreach (var visitor in visitors)
            {
                kolyan.Accept(visitor);
            }
            Console.WriteLine("Итого у Коляна осталось {0}", kolyan.Balance);

            Console.ReadKey();
        }
    }

    public interface IVisitor<T>
    {
        void Visit(IVisitable<T> target);
    }

    public interface IVisitable<T>
    {
        void Accept(IVisitor<T> visitor);
    }

    public interface IPerson
    {
        int Balance { get; set; }
    }

    public class Police : IVisitor<IPerson>
    {
        public void Visit(IVisitable<IPerson> target)
        {
            var balance = ((IPerson)target).Balance -= 2000;
            Console.WriteLine("После ГИБДД у Коляна осталось {0} рублей", balance);
        }
    }

    public class Collectors : IVisitor<IPerson>
    {
        public void Visit(IVisitable<IPerson> target)
        {
            var balance = ((IPerson)target).Balance -= 1000;
            Console.WriteLine("После коллекторов у Коляна осталось {0} рублей", balance);
        }
    }

    public class Kolyan : IVisitable<IPerson>, IPerson
    {
        public int Balance { get; set; }
        public void Accept(IVisitor<IPerson> visitor)
        {
            visitor.Visit(this);
        }
    }
}
