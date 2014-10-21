using System;
using System.Globalization;
using System.ServiceModel;
using System.Threading;

namespace DuplexServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DuplexService : IDuplexService
    {
        public string LongProcess(int value)
        {
           Callback.ClientNotify(DateTime.Now.ToString(CultureInfo.InvariantCulture));
           Thread.Sleep(2000);
           Callback.ClientNotify(DateTime.Now.ToString(CultureInfo.InvariantCulture));
           Thread.Sleep(2000);
           Callback.ClientNotify(DateTime.Now.ToString(CultureInfo.InvariantCulture));
           Thread.Sleep(2000);
           Callback.ClientNotify(DateTime.Now.ToString(CultureInfo.InvariantCulture));
           return "Finish" + value;
        }

        IDuplexCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IDuplexCallback>();
            }
        }
    }
}
