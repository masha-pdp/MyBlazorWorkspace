using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public class ApplicationContextEntity : DbContext
    {
        public DbSet<UserEntity> usersEntity {get;set;}
        public DbSet<CommentEntity> commentsEntity {get;set;}
        public DbSet<OperationEntity> OperationEntitiesEntity { get; set; }


        public ApplicationContextEntity()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=MigDBtest;Username=migdbtest;Password=1212");

    }
}