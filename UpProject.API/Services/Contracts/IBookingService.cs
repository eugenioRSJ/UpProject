using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpProject.API.Commands;
using UpProject.API.Models;

namespace UpProject.API.Services.Contracts
{
    public interface IBookingService
    {
        Task<GenericCommandResult> BookAvailable(ulong id);
        Task<GenericCommandResult> BorrowBook(ulong id, Booking booking);
    }
}