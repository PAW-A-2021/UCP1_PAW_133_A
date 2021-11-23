using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UCPpraktikum.Models
{
    public partial class UCPpraktikumContext : DbContext
    {
        public UCPpraktikumContext()
        {
        }

        public UCPpraktikumContext(DbContextOptions<UCPpraktikumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<ReadingApplication> ReadingApplication { get; set; }
        public virtual DbSet<User> User { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.IdApplication);

                entity.Property(e => e.IdApplication)
                    .HasColumnName("id_Application")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.Property(e => e.IdAdmin)
                    .HasColumnName("id_Admin")
                    .ValueGeneratedNever();

                entity.Property(e => e.NicknameAdmin)
                    .HasColumnName("Nickname_Admin")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.IdAdmin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_Account");
            });

            modelBuilder.Entity<ReadingApplication>(entity =>
            {
                entity.HasKey(e => e.IdBook);

                entity.ToTable("Reading_Application");

                entity.Property(e => e.IdBook)
                    .HasColumnName("id_Book")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionGenre)
                    .HasColumnName("Action_Genre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdventureGenre)
                    .HasColumnName("Adventure_Genre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FantasyGenre)
                    .HasColumnName("Fantasy_Genre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBookNavigation)
                    .WithOne(p => p.ReadingApplication)
                    .HasForeignKey<ReadingApplication>(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reading_Application_Account");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_User")
                    .ValueGeneratedNever();

                entity.Property(e => e.NicknameUser)
                    .HasColumnName("Nickname_User")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Admin");

                entity.HasOne(d => d.IdUser1)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Account");
            });
        }
    }
}
