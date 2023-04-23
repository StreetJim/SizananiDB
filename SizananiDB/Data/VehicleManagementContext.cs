using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SizananiDB.Data
{
    public partial class VehicleManagementContext : DbContext
    {
        public VehicleManagementContext()
        {
        }

        public VehicleManagementContext(DbContextOptions<VehicleManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<ContractorVehicle> ContractorVehicles { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAFAYETTE-PC\\SQLEXPRESS;Initial Catalog=VehicleManagement;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.ToTable("Contractor");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Contractors)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__Contracto__Vehic__440B1D61");
            });

            modelBuilder.Entity<ContractorVehicle>(entity =>
            {
                entity.HasOne(d => d.Contactor)
                    .WithMany(p => p.ContractorVehicles)
                    .HasForeignKey(d => d.ContactorId)
                    .HasConstraintName("FK__Contracto__Conta__47DBAE45");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.ContractorVehicles)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__Contracto__Vehic__46E78A0C");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
