using System;

namespace Polestar.TB.Payments.Lambda.Models.BookingModel;

public class OrderModel
{
    public string OrderId { get; set; }
    public string Status { get; set; }

    public Payment Payment { get; set; }

    public FlightInformation FlightInformation { get; set; }

    public BookingInformation BookingInformation { get; set; }

    public Customer Customer { get; set; }
}

public class Customer
{
    public string CustomerId { get; set; }
    public string[] Bookings { get; set; }
}

public class BookingInformation
{
    public string SystemBookingReference { get; set; }
    public string PublicBookingReference { get; set; }
    public string TokenId { get; set; }
    public string AmountReceived { get; set; }
    public string ArrivalAirport { get; set; }
    public string DepartingAirport { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public string ArrivalDateTime { get; set; }
}

public class FlightInformation
{
    public string SystemBookingReference { get; set; }
    public string TokenId { get; set; }
    public string TotalAmount { get; set; }
    public string Currency { get; set; }
    public string ArrivalAirport { get; set; }
    public string DepartingAirport { get; set; }
    public DateTime DepartureDateTime { get; set; }
    public string ArrivalDateTime { get; set; }
    public string Airline { get; set; }
    public string FlightNumber { get; set; }
}

public class Payment
{
    public string TokenId { get; set; }
    public string SystemBookingReference { get; set; }
    public string Status { get; set; }
    public decimal Amount { get; set; }
}