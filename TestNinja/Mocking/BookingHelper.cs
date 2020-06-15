using System;
using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public static class BookingHelper
    {

        public static string OverlappingBookingsExist(Booking booking,IGetBookings igetBookings)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            //var unitOfWork = new UnitOfWork();
            //var bookings =
            //    unitOfWork.Query<Booking>()
            //        .Where(
            //            b => b.Id != booking.Id && b.Status != "Cancelled");

            var bookings =igetBookings.getBookings(booking);

            var overlappingBooking =
             bookings.FirstOrDefault(
                 b =>
                     booking.ArrivalDate < b.DepartureDate
                     && b.ArrivalDate < booking.DepartureDate
              );

            //  var overlappingBooking = igetBookings.

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }

    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }

    public class Booking : IBooking
    {
        public string Status { get; set; }
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Reference { get; set; }
    }
}