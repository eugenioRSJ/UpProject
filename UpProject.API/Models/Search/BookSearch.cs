using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UpProject.API.Helpers;

namespace UpProject.API.Models.Search
{
    public class BookSearch
    {
        public ulong? Id { get; set; }
        public string? Title { get; set; }
        public string? Autor { get; set; }

        public Expression<Func<Book, bool>> GetSearch()
        {
            Expression<Func<Book, bool>> express = c => true;
            Expression<Func<Book, bool>> auxExpress = c => true;
            if (Id is not null)
            {
                auxExpress = c => c.Id == Id;
                express = ExpressionCombiner.And(express, auxExpress);
            }
            if (Title is not null)
            {
                auxExpress = c => c.Title == Title;
                express = ExpressionCombiner.And(express, auxExpress);
            }

            if (Autor is not null)
            {
                auxExpress = c => c.Autor == Autor;
                express = ExpressionCombiner.And(express, auxExpress);
                
            }

            return express;
        }
    }
}