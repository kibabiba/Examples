using System.ServiceModel;

namespace DuplexServer
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IDuplexCallback))]
    public interface IDuplexService
    {
        [OperationContract]
        string LongProcess(int value);
    }

    public interface IDuplexCallback
    {
        [OperationContract]
        void ClientNotify(string value);
    }
}
