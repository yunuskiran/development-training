using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace RxExtensionBasics.Rx
{
    public class Create
    {
        public static IObservable<string> Blocking()
        {
            var replaySubject = new ReplaySubject<string>();
            replaySubject.OnNext("foo", "bar");
            replaySubject.OnCompleted();
            Thread.Sleep(3000);
            return replaySubject;
        }

        public static IObservable<string> NonBlocking() => Observable.Create<string>(observer =>
                                                                     {
                                                                         observer.OnNext("foo");
                                                                         observer.OnNext("bar");
                                                                         observer.OnCompleted();
                                                                         Thread.Sleep(3000);
                                                                         return Disposable.Empty;
                                                                     });

        public static IObservable<T> Return<T>(T value) => Observable.Create<T>(_ =>
                                                                     {
                                                                         _.OnNext(value);
                                                                         _.OnCompleted();
                                                                         Thread.Sleep(3000);
                                                                         return Disposable.Empty;
                                                                     });
    }
}
