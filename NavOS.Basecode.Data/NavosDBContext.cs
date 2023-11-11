using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NavOS.Basecode.Data.Models;

namespace NavOS.Basecode.Data
{
    public partial class NavosDBContext : DbContext
    {
        public NavosDBContext()
        {
        }

        public NavosDBContext(DbContextOptions<NavosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId)
                    .HasMaxLength(50)
                    .HasColumnName("AdminID");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AdminEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactNo)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Token).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookId)
                    .HasMaxLength(50)
                    .HasColumnName("BookID");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Author).IsRequired();

                entity.Property(e => e.BookTitle).IsRequired();

                entity.Property(e => e.Chapter)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateReleased).HasColumnType("date");

                entity.Property(e => e.Genre).IsRequired();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Summary).IsRequired();

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.GenreId)
                    .HasMaxLength(50)
                    .HasColumnName("GenreID");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GenreDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId)
                    .HasMaxLength(50)
                    .HasColumnName("ReviewID");

                entity.Property(e => e.BookId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("BookID");

                entity.Property(e => e.ReviewText).IsRequired();

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_Reviews_Reviews");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
