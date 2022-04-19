using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpProject.API.Commands;
using UpProject.API.Models;
using UpProject.API.Models.DTO;
using UpProject.API.Models.Search;

namespace UpProject.API.Services.Contracts
{
    public interface IBookService
    {
        Task<GenericCommandResult> InsertOneAsync(Book book);
        Task<GenericCommandResult> FilterByAsync(BookSearch search);
        Task<GenericCommandResult> ReplaceOneAsync(Book book);
        Task<GenericCommandResult> DeleteByIdAsync(ulong id);
        Task<GenericCommandResult> FindByIdAsync(ulong id);
    }
}