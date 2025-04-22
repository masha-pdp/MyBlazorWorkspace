using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> users {get;set;}
        public DbSet<Comment> comments {get;set;}
        public DbSet<OperationEntity> OperationEntities { get; set; }


        public ApplicationContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=MigDBtest;Username=migdbtest;Password=1212");

    }
}