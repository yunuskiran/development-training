using System;
using System.Collections.Immutable;
using System.Reactive.Disposables;

namespace RxExtensionBasics.Rx
{
    public partial class Market : IObservable<float>
    {
        private ImmutableHashSet<IObserver<float>> observers = ImmutableHashSet<IObserver<float>>.Empty;
        public IDisposable Subscribe(IObserver<float> observer)
        {
            observers = observers.Add(observer);
            return Disposable.Create(() =>
            {
                observers = observers.Remove(observer);
            });
        }

        public void Publish(float price)
        {
            foreach (var o in observers)
                o.OnNext(price);
        }
    }
}
