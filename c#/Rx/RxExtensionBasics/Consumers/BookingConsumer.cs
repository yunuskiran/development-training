using Confluent.Kafka;
using RxExtensionBasics.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RxExtensionBasics.Consumers
{
    public class BookingConsumer : IBookingConsumer
    {
        private readonly IBookingStream bookingStream;
        private readonly Action<string> logger;

        public BookingConsumer(IBookingStream bookingStream, Action<string> logger)
        {
            this.bookingStream = bookingStream;
            this.logger = logger;
        }

        public void Listen()
        {
            while (true)
            {
                bookingStream.Publish(new BookingMessage { Message = DateTime.Now.ToShortTimeString() });
            }
        }
    }
}
