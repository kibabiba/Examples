using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main()
        {
            var account = new Account {Login = 105980, Balance = 10};
            var accontObserver = new AccountObserver(account);
            accontObserver.Subscribe(new SomeObserver());
            var unsubscriber = accontObserver.Subscribe(new SomeObserver());
            unsubscriber.Dispose();
            accontObserver.Show();            
        }
    }

    public class Account
    {
        public int Login;
        public double Balance;
    }

    public class AccountObserver : IObservable<Account>
    {
        private readonly List<IObserver<Account>> _observers;
        private readonly Account _account;

        public AccountObserver(Account account)
        {
            _account = account;
            _observers = new List<IObserver<Account>>();
        }

        public IDisposable Subscribe(IObserver<Account> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        public void Show()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(_account);
            }
        }

        private class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<Account>> _observers;
            private readonly IObserver<Account> _observer;

            public Unsubscriber(List<IObserver<Account>> observers, IObserver<Account> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }

    public class SomeObserver : IObserver<Account>
    {
        public void OnNext(Account value)
        {
            Console.WriteLine("{0}: The current balance is {1}", value.Login, value.Balance);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
