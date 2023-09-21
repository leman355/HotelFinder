using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=HotelDb;User Id=postgres;Password=1;Search Path=public");
        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}