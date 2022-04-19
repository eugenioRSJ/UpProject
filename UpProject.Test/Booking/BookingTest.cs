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

    [Fact]
    public void When_trying_to_borrow_a_book_with_the_same_delivery_and_receipt_date_it_should_return_false()
    {
        //Arrange
        var book = new Book(1, "SOLID", "EUGENIO");
        var date = DateTime.Now;
        var booking = new Booking("Júnior", date, date);
        //Act
        var result = book.AddBooking(booking);
        //Assert
        Assert.False(result);
    }
    [Fact]
    public void When_trying_to_borrow_a_book_with_a_later_reservation_the_new_request_must_return_false()
    {
        //Arrange
        var book = new Book(1, "SOLID", "EUGENIO");
        var booking = new Booking("Júnior", DateTime.Now, DateTime.Now.AddDays(2));
        var booking2 = new Booking("Maria", DateTime.Now, DateTime.Now.AddDays(1));

        //Act
        book.AddBooking(booking);
        var result = book.AddBooking(booking2);

        //Assert
        Assert.False(result);
    }



}