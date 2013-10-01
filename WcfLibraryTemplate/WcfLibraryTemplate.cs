using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WcfLibraryTemplate
{
    public class LibraryTemplate<TService> where TService : new()
    {
        private static TService Service
        {
            get
            {
                return new TService();
            }
        }

        protected static TResult MethodTemplate<TResult>(Func<TService, TResult> method)
        {
            dynamic service = Service;
            try
            {
                var result = method(service);
                service.Close();
                return result;
            }
            finally
            {
                if (service.State != CommunicationState.Closed)
                    service.Abort();
            }
        }

        protected static void MethodTemplate(Action<TService> method)
        {
            dynamic service = Service;
            try
            {
                method(service);
                service.Close();
            }
            finally
            {
                if (service.State != CommunicationState.Closed)
                    service.Abort();
            }
        }

        protected static TService SetMaxItemsInObjectGraph(dynamic service)
        {
            foreach (OperationDescription operationDescription in service.Endpoint.Contract.Operations)
            {
                var dataContractSerializer = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (dataContractSerializer != null)
                    dataContractSerializer.MaxItemsInObjectGraph = int.MaxValue;
            }
            return service;
        }

        protected static TService SetInspectorBehavior<TMessageInspector>(dynamic service) where TMessageInspector : IClientMessageInspector, new()
        {
            service.Endpoint.Behaviors.Add(new InspectorBehavior<TMessageInspector>());
            return service;
        }
    }

    public class InspectorBehavior<TMessageInspector> : IEndpointBehavior where TMessageInspector : IClientMessageInspector, new()
    {
        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new TMessageInspector());
        }
    }
}
