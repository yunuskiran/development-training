using RxExtensionBasics.Model;
using System;

public interface IBookingStream
{
    void Publish(BookingMessage bookingMessage);

    void Subscribe(string subscriberName, Action<BookingMessage> action);
}