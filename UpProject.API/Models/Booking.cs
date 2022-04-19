using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace UpProject.API.Models
{
    public class Booking
    {
        public string User { get; private set; }
        public DateTime Borrowed { get; private set; }
        public DateTime Returned { get; private set; }

        public Booking(string user, DateTime borrowed, DateTime returned)
        {
            User = user;
            Borrowed = borrowed;
            Returned = returned;
        }

        public void SetUser(string user)
        {
            User = user;
        }

        public void SetBorrowed(DateTime borrowed)
        {
            Borrowed = borrowed;
        }

        public void SetReturned(DateTime returned)
        {
            Returned = returned;
        }
    }
}