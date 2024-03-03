using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PruebaIngresoBackend.Repository.Models;

namespace PruebaIngresoBackend.Repository;

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
        modelBuilder.Entity<Fligth>(entity =>
        {
            entity.HasKey(e => e.FligthId).HasName("PK__fligth__76261301FBEDCE68");

            entity.Property(e => e.FligthId).ValueGeneratedNever();

            entity.HasOne(d => d.Transport).WithMany(p => p.Fligths)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__fligth__transpor__4D94879B");
        });

        modelBuilder.Entity<Journey>(entity =>
        {
            entity.HasKey(e => e.JourneyId).HasName("PK__journey__B6E9049CA1960992");

            entity.Property(e => e.JourneyId).ValueGeneratedNever();
        });

        modelBuilder.Entity<JourneyFlight>(entity =>
        {
            entity.HasKey(e => e.JourneyFlightId).HasName("PK__journey___EE01FF5AE489D814");

            entity.Property(e => e.JourneyFlightId).ValueGeneratedNever();

            entity.HasOne(d => d.Fligth).WithMany(p => p.JourneyFlights)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__journey_f__fligt__52593CB8");

            entity.HasOne(d => d.Journey).WithMany(p => p.JourneyFlights)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__journey_f__journ__534D60F1");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.TransportId).HasName("PK__transpor__A17E3277E9A38D81");

            entity.Property(e => e.TransportId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
