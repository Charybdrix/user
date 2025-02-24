using System;
using Login.Entities;
using Microsoft.EntityFrameworkCore;

namespace Login.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options
    ): base(options){
    }
    
        public DbSet<User> Users{get; set;}
}
