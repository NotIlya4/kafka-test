﻿using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.EntityFramework;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; private set; } = null!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}