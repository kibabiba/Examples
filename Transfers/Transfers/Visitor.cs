namespace Transfers
{
    public interface IVisitor
    {
        bool Visit(Transfer transfer);
    }

    public class CheckClientVisitor : IVisitor
    {
        public bool Visit(Transfer transfer)
        {
            if (transfer.Client.Login > 10000000)
                return false;
            return true;
        }
    }

    public class CheckUmbrellaVisitor : IVisitor
    {
        public bool Visit(Transfer transfer)
        {
            if (transfer.Umbrella.Login > 1000000)
                return false;
            return true;
        }
    }

    public class CheckSumVisitor : IVisitor
    {
        public bool Visit(Transfer transfer)
        {
            if (transfer.Sum > 100)
                return false;
            return true;
        }
    }
}
