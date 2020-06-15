using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Mocking;
using Moq;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class BookingHelperTests_overlappingBooking
    {
        private Mock<IGetBookings> iBooking;
        private Booking booking;
        [SetUp]
        public void SetUp()
        {

            iBooking = new Mock<IGetBookings>();
             booking = new Booking();
            booking = new Booking()
            {
                Id = 1,
                ArrivalDate = new DateTime(2017, 1, 12, 14, 0, 0),
                DepartureDate = new DateTime(2017, 1, 20, 10, 0, 0),
                Reference = "a"
            };

            iBooking.Setup(b => b.getBookings(It.IsAny<Booking>())).Returns(new List<Booking>{ booking
            }.AsQueryable());

            

        }
        [Test]
        public void newBookingBeforeExistingBooking_ReturnEmptyString()
        {
           

            
            var result=BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(booking.ArrivalDate,2),
                DepartureDate = Before(booking.ArrivalDate),
                Reference = "a"

            }, iBooking.Object);

            Assert.That(result, Is.EqualTo(""));
        }
        [Test]
        public void newBookingBeforeExistingBookingInTheMiddle_ReturnEmptyString()
        {

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(booking.ArrivalDate),
                DepartureDate = After(booking.ArrivalDate),
                Reference = "a"

            }, iBooking.Object);

            Assert.That(result, Is.EqualTo(booking.Reference));
        }
        [Test]
        public void newBookingstartsBeforeExistingBookingendsAfterExistingBooking_ReturnReference()
        {

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            { 
                Id = 1,
                ArrivalDate = Before(booking.ArrivalDate,2),
                DepartureDate = After(booking.DepartureDate,2),
                Reference = "a"

            }, iBooking.Object);

            Assert.That(result, Is.EqualTo(booking.Reference));
        }
        [Test]
        public void newBookingstartsandEndsinMiddlesExistingBooking_ReturnReference()
        {

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(booking.ArrivalDate),
                DepartureDate = Before(booking.DepartureDate),
                Reference = "a"

            }, iBooking.Object);

            Assert.That(result, Is.EqualTo(booking.Reference));
        }

        [Test]
        public void newBookingstartsandEndsinAftersExistingBooking_ReturnReference()
        {

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(booking.ArrivalDate),
                DepartureDate = After(booking.DepartureDate),
                Reference = "a"

            }, iBooking.Object);

            Assert.That(result, Is.EqualTo(booking.Reference));
        }


        [Test]
        public void BookingStartsandFinishesAfterAnExistingBooking_ReturnEmptyString()
        {

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(booking.DepartureDate),
                DepartureDate = After(booking.DepartureDate,2),
                Reference = "a"

            }, iBooking.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void bookingOverlapped_butNewBookingCancelled_ReturnEmptyString()
        {

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(booking.ArrivalDate),
                DepartureDate = After(booking.DepartureDate),
                Reference = "a",
                Status="Cancelled"

            }, iBooking.Object);

            Assert.That(result, Is.Empty);
        }

        private DateTime Before(DateTime dt, int days=1)
        {
            return dt.AddDays(-days);
        }
        private DateTime After(DateTime dt,int days=1)
        {
            return dt.AddDays(days);
        }

        private DateTime ArriveOn(int year,int month,int date)
        {
            return new DateTime(year, month, date, 14, 0, 0);
        }
        private DateTime DepartOn(int year, int month, int date)
        {
            return new DateTime(year, month, date, 10, 0, 0);
        }
    }

}
