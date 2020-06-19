using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace RxExtensionBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            // WithObserver();
            // WithoutRxExtension();
            // WithLambda();
            // WithExtension();
            WithReplaySubject();
            Console.ReadKey();
        }

        static void WithoutRxExtension()
        {
            var market = new Market();
            market.AddPrice += (sender, f) =>
            {
                Console.WriteLine($"Added price {f}");
            };

            market.Add(1);
        }

        static void WithObserver()
        {
            var market = new Market();
        }

        static void WithLambda()
        {
            var market = new Subject<float>();
            market.Subscribe(
                value => Console.WriteLine($"value {value}"),
                () => System.Console.WriteLine("Completed!")
            );

            market.OnNext(1);
            market.OnCompleted();
        }

        static void WithExtension()
        {
            var market = new Subject<float>();
            var marketConsumer = new Subject<float>();
            market.Subscribe(marketConsumer);
            marketConsumer.Inspect("Market Consumer");
            market.OnNext(1, 2, 3, 4, 5);
            market.OnCompleted();
        }

        static void WithReplaySubject()
        {
            //It takes last tree items.
            var market = new ReplaySubject<float>(3);
            market.OnNext(1);
            market.OnNext(2);
            market.OnNext(3);
            market.OnNext(4);
            market.Subscribe(_ => Console.WriteLine($"Value:{_}"));
        }
    }
}
