using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository.Models;

namespace DataAccess.Repository;

public partial class NewshoreAirDbContext : DbContext
{
    public NewshoreAirDbContext()
    {
    }

    public NewshoreAirDbContext(DbContextOptions<NewshoreAirDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fligth> Fligths { get; set; }

    public virtual DbSet<Journey> Journeys { get; set; }

    public virtual DbSet<JourneyFlight> JourneyFlights { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
    }
}
