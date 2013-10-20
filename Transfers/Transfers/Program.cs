using System;

namespace Transfers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("to_preview: ");
            MvcController.to_preview();

            Console.WriteLine();

            Console.WriteLine("to_do: ");
            MvcController.to_do();

            Console.ReadKey();
        }
    }

    public static class MvcController
    {
        private const int ClientLogin = 9500000;
        private const int UmbrellaLogin = 123123;
        private const double Sum = 10.24;

        public static void to_preview()
        {
            var factory = new ToFactory(ClientLogin, UmbrellaLogin, Sum);
            var transferProvider = new TransferProvider(factory);

            transferProvider.DoChekings();
        }

        public static void from_preview()
        {
            var factory = new FromFactory(ClientLogin, UmbrellaLogin, Sum);
            var transferProvider = new TransferProvider(factory);

            transferProvider.DoChekings();
        }

        public static void to_do()
        {
            var factory = new ToFactory(ClientLogin, UmbrellaLogin, Sum);
            var transferProvider = new TransferProvider(factory);
            
            if (transferProvider.DoChekings())
                transferProvider.DoTransfer();
        }

        public static void from_do()
        {
            var factory = new FromFactory(ClientLogin, UmbrellaLogin, Sum);
            var transferProvider = new TransferProvider(factory);

            if (transferProvider.DoChekings())
                transferProvider.DoTransfer();
        }
    }

    /// <summary>
    /// Клиент паттерна Abstract Factory, фигурирует в классическом описании.
    /// Также выполняет роль декоротара для класса Transfer (паттерн Decorator), но без наследования от Transfer
    /// </summary>
    public class TransferProvider
    {
        private readonly Transfer _transfer;

        public TransferProvider(AbstractFactory factory)
        {
            _transfer = factory.GetTransfer();
        }

        public void DoTransfer()
        {           
            _transfer.DoTransfer();
        }

        public bool DoChekings()
        {
            var result = _transfer.DoCheckings();
            Console.WriteLine("Результат проверки: {0}", result);
            return result;
        }
    }
}
