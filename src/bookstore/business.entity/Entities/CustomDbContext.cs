using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace business.entity.Entities
{
    public partial class CustomDbContext : DbContext
    {
        public CustomDbContext()
        {
        }

        public CustomDbContext(DbContextOptions<CustomDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<LiteraryWork> LiteraryWork { get; set; }
        public virtual DbSet<LiteraryWorkAuthor> LiteraryWorkAuthor { get; set; }
        public virtual DbSet<LiteraryWorkGenre> LiteraryWorkGenre { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CBOTULA;Database=bookshop.com;User Id=bookshop.com;Password={0BA77AF7-8FEA-48FB-9FD3-9886D343DAAE};");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "bookshop.com");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apartment)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.House)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostIndex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CityFkNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CityFk)
                    .HasConstraintName("FK__Address__CityFk__4CA06362");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("FK__Address__UserFk__4BAC3F29");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryFkNavigation)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryFk)
                    .HasConstraintName("FK__City__CountryFk__46E78A0C");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "dbo");

                entity.HasIndex(e => e.Abbreviation)
                    .HasName("AK_Country_Abbreviation")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Country_Name")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre", "dbo");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Genre_Name")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LiteraryWork>(entity =>
            {
                entity.ToTable("LiteraryWork", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LiteraryWorkAuthor>(entity =>
            {
                entity.ToTable("LiteraryWorkAuthor", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.AuthorFkNavigation)
                    .WithMany(p => p.LiteraryWorkAuthor)
                    .HasForeignKey(d => d.AuthorFk)
                    .HasConstraintName("FK__LiteraryW__Autho__3E52440B");

                entity.HasOne(d => d.LiteraryWorkFkNavigation)
                    .WithMany(p => p.LiteraryWorkAuthor)
                    .HasForeignKey(d => d.LiteraryWorkFk)
                    .HasConstraintName("FK__LiteraryW__Liter__3D5E1FD2");
            });

            modelBuilder.Entity<LiteraryWorkGenre>(entity =>
            {
                entity.ToTable("LiteraryWorkGenre", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.GenreFkNavigation)
                    .WithMany(p => p.LiteraryWorkGenre)
                    .HasForeignKey(d => d.GenreFk)
                    .HasConstraintName("FK__LiteraryW__Genre__4222D4EF");

                entity.HasOne(d => d.LiteraryWorkFkNavigation)
                    .WithMany(p => p.LiteraryWorkGenre)
                    .HasForeignKey(d => d.LiteraryWorkFk)
                    .HasConstraintName("FK__LiteraryW__Liter__412EB0B6");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "dbo");

                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Role__A25C5AA7DA198091")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Role__737584F6D7AA0A7B")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "dbo");

                entity.HasIndex(e => e.Login)
                    .HasName("AK_User_Login")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NormalizedLogin)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole", "dbo");

                entity.HasIndex(e => new { e.UserFk, e.RoleFk })
                    .HasName("AK_UserRole_UserFk_RoleFk")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.RoleFkNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__RoleFk__00200768");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__UserFk__7F2BE32F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
