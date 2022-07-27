using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OfferMicroservice.Models
{
    public partial class ClassifiedsContext : DbContext
    {
        public ClassifiedsContext()
        {
        }

        public ClassifiedsContext(DbContextOptions<ClassifiedsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=VAMSI;Initial Catalog=Classifieds;Integrated Security=True ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>(entity =>
            //{
            //    entity.Property(e => e.EmployeeId).ValueGeneratedNever();

            //    entity.Property(e => e.EmployeeName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Password)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.OfferId).ValueGeneratedNever();

                entity.Property(e => e.Likes).HasColumnName("int");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ClosedDate).HasColumnType("datetime");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EngagedDate).HasColumnType("datetime");

                entity.Property(e => e.OpenedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                //entity.HasOne(d => d.Employee)
                //    .WithMany(p => p.Offer)
                //    .HasForeignKey(d => d.EmployeeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Offer_Employee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
