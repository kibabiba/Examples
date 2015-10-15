using System;

namespace DelegateEventFuncExample
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class Program
    {
        private delegate double Fx(double x);

        private static event Fx MyEvent;
        private static event Func<double, double> MyEvent2;

        static void Main()
        {
            ShowGraph(x => x * x);
            ShowGraph(Paraboloa);

            ShowGraph2(x => x * x);
            ShowGraph2(Paraboloa);

            MyEvent += Paraboloa;
            MyEvent += x => x * x;

            MyEvent2 += Paraboloa;
            MyEvent2 += x => x * x;

            MyEvent(new double());
            MyEvent2(new double());
        }

        private static void ShowGraph(Fx fx)
        {
            for (int x = 0; x < 10; x++)
            {
                Console.WriteLine(fx(x));
            }
        }

        private static void ShowGraph2(Func<double, double> fx)
        {
            for (int x = 0; x < 10; x++)
            {
                Console.WriteLine(fx(x));
            }
        }

        private static double Paraboloa(double x)
        {
            return x * x;
        }
    }
}
