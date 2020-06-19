using System;
using System.Linq;

namespace RxExtensionBasics
{
    public static class RxExtensions
    {
        public static IDisposable Inspect<T>(this IObservable<T> self, string name) => self.Subscribe(
                onNext => System.Console.WriteLine($"{name} Value: {onNext}"),
                onError => System.Console.WriteLine($"{name} has exception {onError.Message}"),
                () => System.Console.WriteLine("Completed!")
            );

        public static IObserver<T> OnNext<T>(this IObserver<T> self,
            params T[] args)
        {
            foreach (var item in args)
                self.OnNext(item);
            return self;
        }
    }
}