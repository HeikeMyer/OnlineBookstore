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
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<DataStorage> DataStorage { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<LiteraryWork> LiteraryWork { get; set; }
        public virtual DbSet<LiteraryWorkAuthor> LiteraryWorkAuthor { get; set; }
        public virtual DbSet<LiteraryWorkGenre> LiteraryWorkGenre { get; set; }
        public virtual DbSet<LiteraryWorkSummary> LiteraryWorkSummary { get; set; }
        public virtual DbSet<LoginActivity> LoginActivity { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<OperationType> OperationType { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
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

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.House)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostIndex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CityFkNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CityFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__CityFk__5629CD9C");

                entity.HasOne(d => d.CountryFkNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__Country__5535A963");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__UserFk__5441852A");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.ToTable("Basket", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PaymentFkNavigation)
                    .WithMany(p => p.Basket)
                    .HasForeignKey(d => d.PaymentFk)
                    .HasConstraintName("FK__Basket__PaymentF__2DE6D218");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Basket)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Basket__UserFk__2CF2ADDF");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.LiteraryWorkFkNavigation)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.LiteraryWorkFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book__LiteraryWo__04E4BC85");

                entity.HasOne(d => d.PublisherFkNavigation)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.PublisherFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book__PublisherF__05D8E0BE");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Book__UpdatedBy__08B54D69");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__City__CountryFk__5165187F");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "dbo");

                entity.HasIndex(e => e.Abbreviation)
                    .HasName("UQ__Country__9C41170E8BDB7B33")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Country__737584F600DE0DCD")
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

            modelBuilder.Entity<DataStorage>(entity =>
            {
                entity.ToTable("DataStorage", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Data).IsRequired();
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item", "dbo");

                entity.HasIndex(e => e.Barcode)
                    .HasName("UQ__Item__177800D354C1BA6F")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.BookFkNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.BookFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__BookFk__0E6E26BF");

                entity.HasOne(d => d.ProviderFkNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.ProviderFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__ProviderFk__0F624AF8");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Item__UpdatedBy__123EB7A3");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language", "dbo");

                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Language__A25C5AA700B82DB4")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Language__737584F63815F151")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LiteraryWork>(entity =>
            {
                entity.ToTable("LiteraryWork", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.LiteraryWorkSummaryFkNavigation)
                    .WithMany(p => p.LiteraryWork)
                    .HasForeignKey(d => d.LiteraryWorkSummaryFk)
                    .HasConstraintName("FK__LiteraryW__Liter__6EF57B66");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.LiteraryWork)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LiteraryW__Updat__71D1E811");
            });

            modelBuilder.Entity<LiteraryWorkAuthor>(entity =>
            {
                entity.ToTable("LiteraryWorkAuthor", "dbo");

                entity.HasIndex(e => new { e.LiteraryWorkFk, e.AuthorFk })
                    .HasName("AK_LiteraryWorkAuthor_LiteraryWorkFk_AuthorFk")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.AuthorFkNavigation)
                    .WithMany(p => p.LiteraryWorkAuthor)
                    .HasForeignKey(d => d.AuthorFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LiteraryW__Autho__76969D2E");

                entity.HasOne(d => d.LiteraryWorkFkNavigation)
                    .WithMany(p => p.LiteraryWorkAuthor)
                    .HasForeignKey(d => d.LiteraryWorkFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LiteraryW__Liter__75A278F5");
            });

            modelBuilder.Entity<LiteraryWorkGenre>(entity =>
            {
                entity.ToTable("LiteraryWorkGenre", "dbo");

                entity.HasIndex(e => new { e.LiteraryWorkFk, e.GenreFk })
                    .HasName("AK_LiteraryWorkGenre_LiteraryWorkFk_GenreFk")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.GenreFkNavigation)
                    .WithMany(p => p.LiteraryWorkGenre)
                    .HasForeignKey(d => d.GenreFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LiteraryW__Genre__7B5B524B");

                entity.HasOne(d => d.LiteraryWorkFkNavigation)
                    .WithMany(p => p.LiteraryWorkGenre)
                    .HasForeignKey(d => d.LiteraryWorkFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LiteraryW__Liter__7A672E12");
            });

            modelBuilder.Entity<LiteraryWorkSummary>(entity =>
            {
                entity.ToTable("LiteraryWorkSummary", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DataStorageFkNavigation)
                    .WithMany(p => p.LiteraryWorkSummary)
                    .HasForeignKey(d => d.DataStorageFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LiteraryW__DataS__68487DD7");

                entity.HasOne(d => d.LanguageFkNavigation)
                    .WithMany(p => p.LiteraryWorkSummary)
                    .HasForeignKey(d => d.LanguageFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LiteraryW__Langu__6754599E");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.LiteraryWorkSummary)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LiteraryW__Updat__6B24EA82");
            });

            modelBuilder.Entity<LoginActivity>(entity =>
            {
                entity.ToTable("LoginActivity", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(46)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddressRaw)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength();

                entity.Property(e => e.LoginDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.LoginActivity)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoginActi__UserF__3F466844");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OperationTypeFkNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.OperationTypeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Opera__1AD3FDA4");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__UserF__19DFD96B");
            });

            modelBuilder.Entity<OperationType>(entity =>
            {
                entity.ToTable("OperationType", "dbo");

                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Operatio__A25C5AA7A4335B74")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PaymentMethodFkNavigation)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.PaymentMethodFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__Payment__2739D489");

                entity.HasOne(d => d.PaymentStatusFkNavigation)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.PaymentStatusFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__Payment__282DF8C2");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__UserFk__2645B050");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod", "dbo");

                entity.HasIndex(e => e.Code)
                    .HasName("UQ__PaymentM__A25C5AA79E9B159D")
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

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.ToTable("PaymentStatus", "dbo");

                entity.HasIndex(e => e.Code)
                    .HasName("UQ__PaymentS__A25C5AA71BBCE341")
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

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider", "dbo");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Provider__737584F68D5F4381")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("Publisher", "dbo");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Publishe__737584F6E4D8B857")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("Purchase", "dbo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.BasketFkNavigation)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.BasketFk)
                    .HasConstraintName("FK__Purchase__Basket__37703C52");

                entity.HasOne(d => d.ItemFkNavigation)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.ItemFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Purchase__ItemFk__3864608B");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Purchase__UserFk__367C1819");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "dbo");

                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Role__A25C5AA77ED76C80")
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

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("UQ__User__368B291AB3966035")
                    .IsUnique();

                entity.HasIndex(e => e.NormalizedLogin)
                    .HasName("UQ__User__7D6748E7661FDD55")
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

                entity.Property(e => e.NormalizedEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedLogin)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
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

                entity.Property(e => e.Updated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.RoleFkNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__RoleFk__46E78A0C");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.UserRoleUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__Update__49C3F6B7");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.UserRoleUserFkNavigation)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__UserFk__45F365D3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
