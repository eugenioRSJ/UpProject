using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using UpProject.API.Models.Base;

namespace UpProject.API.Models
{
    [BsonCollection("Book")]
    public class Book : Document
    {   
        public string Title { get; private set; }
        public string Autor { get; private set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();

        public Book(ulong id, string title, string autor)
        {
            Id = id;
            Title = title;
            Autor = autor;
        }

        private Book(){}

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetAutor(string autor)
        {
            Autor = autor;
        }

        public bool BookAvailable()
        {
            if(Bookings == null || Bookings.Count == 0)
                return true;
            
            var returnedMoreNow = Bookings.Where(x => x.Returned >= DateTime.Now).ToList().Count >= 0;
            if(returnedMoreNow)
                return false;

            return true;   
        }

        public bool AddBooking(Booking booking)
        {
            if(BookAvailable())
            {
                if(booking.Returned <= booking.Borrowed)
                    return false;
                Bookings.Add(booking);
                return true;
            }
            return false; 
        }
    }
}