using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using UpProject.API.Commands;
using UpProject.API.Helpers;
using UpProject.API.Models;
using UpProject.API.Models.DTO;
using UpProject.API.Models.Search;
using UpProject.API.Repository.Contract;
using UpProject.API.Services.Contracts;

namespace UpProject.API.Services
{
    public class BookService : IBookService
    {
        private readonly IBaseRepository<Book> _repository;

        public BookService(IBaseRepository<Book> repository)
        {
            _repository = repository;
        }


        public async Task<GenericCommandResult> FilterByAsync(BookSearch search)
        {
            var result = await _repository.FilterByAsync(search.GetSearch());
            if (result is null) return new GenericCommandResult(false, Messages.ErrorSearch, search);
            
            return new GenericCommandResult(true, Messages.SuccessGeneric, result.OrderBy(x=> x.Bookings.Count));
        }

        public async Task<GenericCommandResult> InsertOneAsync(Book book)
        {
            try
            {
                await _repository.InsertOneAsync(book);
                return new GenericCommandResult(true, Messages.SuccessInsert, book);
            }
            catch (MongoWriteException ex)
            {
                var error = ex.WriteError.Code;
                if (error == 11000)
                    return new GenericCommandResult(false, Messages.IdentifyExist, book);
                else
                    throw ex;
            }
        }

        public async Task<GenericCommandResult> ReplaceOneAsync(Book book)
        {
            var bookCommand = await FindByIdAsync(book.Id);
            if(!bookCommand.Success)
                return bookCommand;

            await _repository.ReplaceOneAsync(book);
            return new GenericCommandResult(true, Messages.SuccessUpdate, book);
        }

        public async Task<GenericCommandResult> DeleteByIdAsync(ulong id)
        {
            var bookCommand = await FindByIdAsync(id);
            if(!bookCommand.Success)
                return bookCommand;
            await _repository.DeleteByIdAsync(id);
            return new GenericCommandResult(true, Messages.SuccessDelete, null);
        }

        public async Task<GenericCommandResult> FindByIdAsync(ulong id)
        {
            var result = await _repository.FindByIdAsync(id);
            if(result == null)
                return new GenericCommandResult(false, Messages.IdentifyNotExist, null);

            return new GenericCommandResult(true, Messages.SuccessSearch, result);
        }

    }
}