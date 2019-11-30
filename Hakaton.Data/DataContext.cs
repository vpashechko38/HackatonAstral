using System;
using System.Collections.Generic;
using System.Text;
using Hakaton.Domain.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Hakaton.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Service> Services { get; set; }

        public DbSet<PathPhoto> PathPhotos { get; set; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }
        
    }
}
