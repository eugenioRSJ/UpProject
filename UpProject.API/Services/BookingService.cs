using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpProject.API.Commands;
using UpProject.API.Models;
using UpProject.API.Services.Contracts;

namespace UpProject.API.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookService _bookService;

        public BookingService(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<GenericCommandResult> BookAvailable(ulong id)
        {
            var bookCommand = await _bookService.FindByIdAsync(id);
            if(!bookCommand.Success) return bookCommand;

            var book = bookCommand.Data as Book;

            var resp = book.BookAvailable() ? "Book available" : "Book not available";
            return new GenericCommandResult(true, "Verification success",  resp);
        }

        public async Task<GenericCommandResult> BorrowBook(ulong id, Booking booking)
        {
            var bookCommand = await _bookService.FindByIdAsync(id);
            if(!bookCommand.Success) return bookCommand;

            var book = bookCommand.Data as Book;
            if(book.AddBooking(booking))
            {
            
                return await _bookService.ReplaceOneAsync(book);
    
            }
            
            return new GenericCommandResult(false, "Error booking book", booking);
        }
    }
}