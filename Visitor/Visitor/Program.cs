using System;
using System.Collections.Generic;

namespace Visitor
{
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
            Console.WriteLine("Итого у Коляна осталось {0}", kolyan.Balance);
        }
    }

    public interface IVisitor
    {
        void Visit(Kolyan kolyan);
    }

    public class Police : IVisitor
    {
        public void Visit(Kolyan kolyan)
        {
            kolyan.Balance -= 1000;
            Console.WriteLine("После ГИБДД у Каляна осталось {0} рублей", kolyan.Balance);
        }
    }

    public class Collectors : IVisitor
    {
        public void Visit(Kolyan kolyan)
        {
            kolyan.Balance -= 2000;
            Console.WriteLine("После Колекторов у Каляна осталось {0} рублей", kolyan.Balance);
        }
    }

    public class Kolyan
    {
        public int Balance;

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
