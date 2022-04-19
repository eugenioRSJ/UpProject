using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpProject.API.Models.DTO
{
    public class BookDTO
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }

        public Book DtoInEntity()
        {

            return new Book(Id, Title, Autor);
        }
    }
}