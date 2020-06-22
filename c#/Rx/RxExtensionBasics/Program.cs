using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using RxExtensionBasics.Rx;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Reactive.Disposables;

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
            // WithReplaySubject();
            // WithBehaviourSubject();
            // WithAsyncSubject();
            // WithObservable();
            // Factories();
            // Blocking();
            // NonBlocking();
            OperatorsReturn();

            Console.ReadKey();
        }

        static void WithoutRxExtension()
        {
            var market = new Design.Market();
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

        static void WithBehaviourSubject()
        {
            var market = new BehaviorSubject<float>(1);
            market.Inspect("market");
            market.OnNext(2);
            market.OnCompleted();
        }

        static void WithAsyncSubject()
        {
            var market = new AsyncSubject<float>();
            market.Inspect("market");
            market.OnNext(1);
            market.OnNext(2);
            market.OnNext(3);
            market.OnCompleted();
        }

        static void WithObservable()
        {
            var market = new Market();
            var subscription = market.Inspect("market");
            market.Publish(123);
            subscription.Dispose();
        }

        static void Factories()
        {
            var observableReturn = Observable.Return(1); //Return 1;
            observableReturn.Inspect("Return");
            var observableEmpty = Observable.Empty<int>(); //Return Empty;
            observableEmpty.Inspect("ReturnEmpty");
            var observableNever = Observable.Never<int>(); //Never return;
            observableNever.Inspect("ReturnNever");
            var observableException = Observable.Throw<int>(new Exception("error")); //Throw Exception;
            observableException.Inspect("Exception");
        }

        static void Blocking()
        {
            Create.Blocking().Inspect("Blocking");
        }

        static void NonBlocking()
        {
            Create.NonBlocking().Inspect("NonBlocking");
        }

        static void OperatorsReturn()
        {
            var observable = Observable.Create<string>(_ =>
            {
                var timer = new Timer(1000);
                timer.Elapsed += (sender, e) => _.OnNext($"tick {e.SignalTime}");
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
                return Disposable.Empty;
            });

            var subscriber = observable.Inspect("timer");
            Console.ReadKey();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
            => Console.WriteLine($"tock {e.SignalTime}");
    }
}
