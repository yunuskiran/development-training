﻿using RxExtensionBasics.Model;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxExtensionBasics.Handlers
{
    public class BookingStream : IBookingStream, IDisposable
    {
        private Subject<BookingMessage> bookingMessageSubject;
        private IDictionary<string, IDisposable> subscribers;

        public BookingStream()
        {
            bookingMessageSubject = new Subject<BookingMessage>();
            subscribers = new Dictionary<string, IDisposable>();
        }

        public void Dispose()
        {
            if (bookingMessageSubject != null)
            {
                bookingMessageSubject.Dispose();
            }

            foreach (var subscriber in subscribers)
            {
                subscriber.Value.Dispose();
            }
        }

        public void Publish(BookingMessage bookingMessage)
        {
            bookingMessageSubject.OnNext(bookingMessage);
        }

        public void Subscribe(string subscriberName, Action<BookingMessage> action)
        {
            if (!subscribers.ContainsKey(subscriberName))
            {
                subscribers.Add(subscriberName, bookingMessageSubject.Where(m => m.Message.Length > 0).Subscribe(action));
            }
        }
    }
}
