﻿using Microsoft.EntityFrameworkCore;
using RatingDemoTest.Domain;
using System;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RatingDemoTest
{
    public class RatingDemoContext : DbContext 
    {
        public virtual DbSet<ServicesRating> ServicesRating { get; set; }
        public virtual DbSet<LoginServices> LoginServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=serverName;Database=RatingDemoTest;Integrated Security=False;User ID=username;Password=password;");
        }
    }
}
