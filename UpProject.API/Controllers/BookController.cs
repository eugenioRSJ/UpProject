using Microsoft.AspNetCore.Mvc;
using UpProject.API.Models;
using UpProject.API.Models.DTO;
using UpProject.API.Models.Search;
using UpProject.API.Repository.Contract;
using UpProject.API.Services;
using UpProject.API.Services.Contracts;

namespace UpProject.API.Controllers;

[ApiController]
[Route("book/id")]
public class BookController : ControllerBase
{
    /// <summary>
    /// Method that inserts a book.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> InsertBook([FromBody]BookDTO dto, [FromServices] IBookService service)
    {
        var result = await service.InsertOneAsync(dto.DtoInEntity());
        if(result.Success)
        {
            return Ok(result);
        }

        return UnprocessableEntity(result);
    }

    /// <summary>
    /// Method that searches one or several books depending on the search parameters.
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]BookSearch search, [FromServices] IBookService service)
    {
        var result = await service.FilterByAsync(search);
        if(result.Success)
        {
            return Ok(result);
        }

        return UnprocessableEntity(result);
    }

    /// <summary>
    /// Method that updates a book.
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="service"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> DeleteByIdAsync([FromQuery]BookDTO dto, [FromServices] IBookService service)
    {
        var result = await service.ReplaceOneAsync(dto.DtoInEntity());
        if(result.Success)
        {
            return Ok(result);
        }

        return UnprocessableEntity(result);
    }

    /// <summary>
    /// Method that deletes a book.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="service"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteByIdAsync([FromQuery]ulong id, [FromServices] IBookService service)
    {
        var result = await service.DeleteByIdAsync(id);
        if(result.Success)
        {
            return Ok(result);
        }

        return UnprocessableEntity(result);
    }

}
