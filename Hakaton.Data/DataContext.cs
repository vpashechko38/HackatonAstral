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
        public DbSet<User> Users { get; set; }
        public DbSet<PathPhoto> PathPhotos { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(u => u.UserId);
                user.Property(u => u.UserId).ValueGeneratedOnAdd();
                user.HasIndex(u => u.Login).IsUnique();
                user.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<PathPhoto>(photo =>
            {
                photo.HasKey(p => p.PhotoId);
                photo.Property(p => p.PhotoId).ValueGeneratedOnAdd();
            });
        }
    }
}
