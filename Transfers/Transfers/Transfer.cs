using System;

namespace Transfers
{
    public abstract class Transfer
    {
        public readonly User Client;
        public readonly User Umbrella;
        public readonly double Sum;

        protected Transfer(User client, User umbrella, double sum)
        {
            Client = client;
            Umbrella = umbrella;
            Sum = sum;
        }

        public abstract void DoTransfer();

        public bool DoCheckings() //можно объявить абстрактным и переопределить для каждого вида трансфера 
        {
            var visitors = new IVisitor[] {new CheckClientVisitor(), new CheckUmbrellaVisitor(), new CheckSumVisitor()};
            foreach (var visitor in visitors)
            {
                if (!visitor.Visit(this))
                    return false;
            }
            return true;
        }
    }

    public class Mt4TransferTo : Transfer
    {
        public Mt4TransferTo(User client, User umbrella, double sum) : base(client, umbrella, sum)
        {
        }

        public override void DoTransfer()
        {
            Console.WriteLine("Переводит {0} с МТ4 {1} на амбрелу {2}", Sum, Client.Login, Umbrella.Login);
            Client.DoBalanceOperation(-Sum);
            Umbrella.DoBalanceOperation(Sum);
        }
    }

    public class Mt4TransferFrom : Transfer
    {
        public Mt4TransferFrom(User client, User umbrella, double sum) : base(client, umbrella, sum)
        {
        }

        public override void DoTransfer()
        {
            Console.WriteLine("Переводит {0} с амбреллы {2} на МТ4 {1}", Sum, Client.Login, Umbrella.Login);
            Client.DoBalanceOperation(Sum);
            Umbrella.DoBalanceOperation(-Sum);
        }
    }

    public class Mt5TransferTo : Transfer
    {
        public Mt5TransferTo(User client, User umbrella, double sum) : base(client, umbrella, sum)
        {
        }

        public override void DoTransfer()
        {
            Console.WriteLine("Переводит {0} с МТ5 {1} на амбрелу {2}", Sum, Client.Login, Umbrella.Login);
            Client.DoBalanceOperation(-Sum);
            Umbrella.DoBalanceOperation(Sum);
        }
    }

    public class Mt5TransferFrom : Transfer
    {
        public Mt5TransferFrom(User client, User umbrella, double sum) : base(client, umbrella, sum)
        {
        }

        public override void DoTransfer()
        {
            Console.WriteLine("Переводит {0} с амбреллы {2} на МТ5 {1}", Sum, Client.Login, Umbrella.Login);
            Client.DoBalanceOperation(Sum);
            Umbrella.DoBalanceOperation(-Sum);
        }
    }

    public class PammTransferTo : Transfer
    {
        public PammTransferTo(User client, User umbrella, double sum) : base(client, umbrella, sum)
        {
        }

        public override void DoTransfer()
        {
            Console.WriteLine("Переводит {0} с ПАММ {1} на амбрелу {2}", Sum, Client.Login, Umbrella.Login);
            Client.DoBalanceOperation(-Sum);
            Umbrella.DoBalanceOperation(Sum);
        }
    }

    public class PammTransferFrom : Transfer
    {
        public PammTransferFrom(User client, User umbrella, double sum) : base(client, umbrella, sum)
        {
        }

        public override void DoTransfer()
        {
            Console.WriteLine("Переводит {0} с амбреллы {2} на ПАММ {1}", Sum, Client.Login, Umbrella.Login);
            Client.DoBalanceOperation(Sum);
            Umbrella.DoBalanceOperation(-Sum);
        }
    }
}
