using Xunit;
using UpProject.API.Models;
using System;

namespace UpProject.Test.BookingTests;


public class BookingTest
{
    [Fact]
    public void When_trying_to_borrow_a_book_without_a_previous_loan_it_should_return_true()
    {
        //Arrange
        var book = new Book(1, "SOLID", "EUGENIO");
        var booking = new Booking("Júnior", DateTime.Now, DateTime.Now.AddDays(1));
        //Act
        var result = book.AddBooking(booking);
        //Assert
        Assert.True(result);
    }
}