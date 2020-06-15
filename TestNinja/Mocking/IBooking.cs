using System;

namespace TestNinja.Mocking
{
    public interface IBooking
    {
        DateTime ArrivalDate { get; set; }
        DateTime DepartureDate { get; set; }
        int Id { get; set; }
        string Reference { get; set; }
        string Status { get; set; }
    }
}