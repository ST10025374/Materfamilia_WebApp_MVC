using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SampleApp.Models;

public partial class MaterDBContext : IdentityDbContext
{
    public MaterDBContext()
    {
    }

    public MaterDBContext(DbContextOptions<MaterDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }



    public virtual DbSet<DonationInterest> DonationInterests { get; set; }

    public virtual DbSet<MediaContent> MediaContents { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Notes)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

       

        modelBuilder.Entity<DonationInterest>(entity =>
        {
            entity.HasKey(e => e.DonationId);

            entity.ToTable("DonationInterest");

            entity.Property(e => e.AmountPledged).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DateSubmitted).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MediaContent>(entity =>
        {
            entity.HasKey(e => e.MediaId);

            entity.ToTable("MediaContent");

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .IsUnicode(false)
                .HasColumnName("URL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
