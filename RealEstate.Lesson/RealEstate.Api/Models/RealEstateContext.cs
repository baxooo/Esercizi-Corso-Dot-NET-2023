using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RealEstate.Api.Models
{
    public partial class RealEstateContext : DbContext
    {
        public RealEstateContext()
        {
        }

        public RealEstateContext(DbContextOptions<RealEstateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=RealEstate; User id = sa ; password = Password.123;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CommentText).HasMaxLength(500);

                entity.Property(e => e.DatePosted).HasColumnType("datetime");

                entity.Property(e => e.IssueId).HasColumnName("IssueID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IssueId)
                    .HasConstraintName("FK__Comments__IssueI__412EB0B6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comments__UserID__4222D4EF");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.ToTable("House");

                entity.Property(e => e.HouseId).HasColumnName("HouseID");

                entity.Property(e => e.BuildingNumber).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.Flat).HasMaxLength(50);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Street).HasMaxLength(100);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__House__OwnerID__398D8EEE");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.Property(e => e.IssueId).HasColumnName("IssueID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.HouseId).HasColumnName("HouseID");

                entity.Property(e => e.ReportedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.House)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.HouseId)
                    .HasConstraintName("FK__Issues__HouseID__3D5E1FD2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Issues__UserID__3E52440B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
