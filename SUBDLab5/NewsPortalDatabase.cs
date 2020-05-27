using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SUBDLab5.Models;

namespace SUBDLab5
{
    public class NewsPortalDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=HOME-PC;Initial Catalog=NewsPortalDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Username>().HasIndex(c => c.Nickname);
           modelBuilder.Entity<News>().HasIndex(c => c.Title);
           modelBuilder.Entity<Author>().HasIndex(c => c.Name);
        }
        public virtual DbSet<Author> Authors { set; get; }
        public virtual DbSet<Category> Categories { set; get; }
        public virtual DbSet<Comment> Comments { set; get; }
        public virtual DbSet<News> News { set; get; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Username> Usernames { get; set; }
    }
}