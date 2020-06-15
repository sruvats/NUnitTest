using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IGetBookings
    {
        IQueryable<Booking> getBookings(Booking booking);
    }

    public class GetBookings : IGetBookings
    {
        public IQueryable<Booking> getBookings(Booking booking)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Id != booking.Id && b.Status != "Cancelled");
            return bookings;

            
        }

        //public Booking overlappingBook(Booking booking)
        //{

        //    var bookings= getBookings(booking);

        //    var overlappingBooking =
        //      bookings.FirstOrDefault(
        //          b =>
        //              booking.ArrivalDate >= b.ArrivalDate
        //              && booking.ArrivalDate < b.DepartureDate
        //              || booking.DepartureDate > b.ArrivalDate
        //              && booking.DepartureDate <= b.DepartureDate);

        //    return overlappingBooking;
        //}
    }
}
