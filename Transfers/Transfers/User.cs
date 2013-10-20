using System;

namespace Transfers
{
    public abstract class User
    {
        public int Login { private set; get; }

        protected User(int login)
        {
            Login = login;
        }

        public abstract void DoBalanceOperation(double sum);
    }

    public class Mt4User : User
    {
        public Mt4User(int login) : base(login)
        {
        }

        public override void DoBalanceOperation(double sum)
        {
            Console.WriteLine("МТ4 балансовая операция на {0}", sum);
        }
    }

    public class Mt5User : User
    {
        public Mt5User(int login) : base(login)
        {
        }

        public override void DoBalanceOperation(double sum)
        {
            Console.WriteLine("МТ5 балансовая операция на {0}", sum);
        }
    }

    public class PammUser : User
    {
        public PammUser(int login) : base(login)
        {
        }

        public override void DoBalanceOperation(double sum)
        {
            Console.WriteLine("PAMM балансовая операция на {0}", sum);
        }
    }

    public class UmbrellaUser : User
    {
        public UmbrellaUser(int login) : base(login)
        {
        }

        public override void DoBalanceOperation(double sum)
        {
            Console.WriteLine("Umbrella балансовая операция на {0}", sum);
        }
    }
}
