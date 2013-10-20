namespace Transfers
{
    /// <summary>
    /// Паттерн Abstract Factory
    /// </summary>
    public abstract class AbstractFactory
    {
        protected readonly int ClientLogin;
        protected readonly int UmbrellaLogin;
        protected readonly double Sum;

        protected AbstractFactory(int clientLogin, int umbrellaLogin, double sum)
        {
            ClientLogin = clientLogin;
            UmbrellaLogin = umbrellaLogin;
            Sum = sum;
        }

        public User GetClient() //одинаковый для To и From
        {
            if (Common.IsMt5(ClientLogin))
                return new Mt5User(ClientLogin);
            if (Common.IsPamm(ClientLogin))
                return new Mt5User(ClientLogin);
            return new Mt4User(ClientLogin);
        }

        public User GetUmbrella() //одинаковый для To и From
        {
            return new UmbrellaUser(UmbrellaLogin);
        }

        public abstract Transfer GetTransfer();
    }

    public class FromFactory : AbstractFactory
    {
        public FromFactory(int clientLogin, int umbrellaLogin, double sum) : base(clientLogin, umbrellaLogin, sum)
        {
        }

        public override Transfer GetTransfer()
        {
            if (Common.IsMt5(ClientLogin))
                return new Mt5TransferFrom(GetClient(), GetUmbrella(), Sum);
            if (Common.IsPamm(ClientLogin))
                return new PammTransferFrom(GetClient(), GetUmbrella(), Sum);
            return new Mt4TransferFrom(GetClient(), GetUmbrella(), Sum);
        }
    }

    public class ToFactory : AbstractFactory
    {
        public ToFactory(int clientLogin, int umbrellaLogin, double sum) : base(clientLogin, umbrellaLogin, sum)
        {
        }

        public override Transfer GetTransfer()
        {
            if (Common.IsMt5(ClientLogin))
                return new Mt5TransferTo(GetClient(), GetUmbrella(), Sum);
            if (Common.IsPamm(ClientLogin))
                return new PammTransferTo(GetClient(), GetUmbrella(), Sum);
            return new Mt4TransferTo(GetClient(), GetUmbrella(), Sum);
        }
    }
}
