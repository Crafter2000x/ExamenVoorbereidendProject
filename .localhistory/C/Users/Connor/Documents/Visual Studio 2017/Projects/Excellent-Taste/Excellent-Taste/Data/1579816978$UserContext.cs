﻿using Excellent_Taste.Models;
using Microsoft.EntityFrameworkCore;

namespace Excellent_Taste.Data 
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }

}
