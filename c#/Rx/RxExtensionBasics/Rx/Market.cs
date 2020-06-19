using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;

namespace RxExtensionBasics
{
    public partial class Market
        : IObserver<float>
    {
        public Market()
        {
            var market = new Subject<float>();
            market.Subscribe(this);
            market.OnNext(1);
            market.OnCompleted();
        }

        //Works like OnNext -> (OnError | Oncompleted) ? 
        public void OnCompleted() => Console.WriteLine("Completed!");

        public void OnError(Exception error) => Console.WriteLine($"Oopps! {error}");

        public void OnNext(float value) => Console.WriteLine($"Value {value}");
    }
}