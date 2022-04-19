using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UpProject.API.Models;
using UpProject.API.Services.Contracts;

namespace UpProject.API.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookingController : ControllerBase
    {
        [HttpGet("{id}/loan")]
        public async Task<IActionResult> BookAvailable([FromRoute] ulong id, [FromServices] IBookingService service)
        {
            var result = await service.BookAvailable(id);
            if(result.Success)
                return Ok(result);
            return UnprocessableEntity(result);
        }
        
        [HttpPost("{id}/loan")]
        public async Task<IActionResult> BorrowBook([FromRoute] ulong id, [FromBody] Booking booking, [FromServices] IBookingService service)
        {
            var result = await service.BorrowBook(id, booking);
            if(result.Success)
                return Ok(result);
            return UnprocessableEntity(result);
        }
    }
}