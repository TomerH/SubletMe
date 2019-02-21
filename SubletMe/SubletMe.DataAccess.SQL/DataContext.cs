using SubletMe.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubletMe.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
