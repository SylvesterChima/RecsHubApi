using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RecsHub.Domain.Abstract;

namespace RecsHub.Domain.Entities
{
    public partial class RecsHubContext : DbContext, IDbContext
    {
        public RecsHubContext()
        {
        }

        public RecsHubContext(DbContextOptions<RecsHubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<DailyStoreRecord> DailyStoreRecords { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SalesItem> SalesItems { get; set; }
        public virtual DbSet<SalesMaster> SalesMasters { get; set; }
        public virtual DbSet<StockKeeping> StockKeepings { get; set; }
        public virtual DbSet<StoreRecord> StoreRecords { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplyRecord> SupplyRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.CompanyKey).HasDefaultValueSql("(N'')");

                entity.Property(e => e.FirstName).HasDefaultValueSql("(N'')");

                entity.Property(e => e.LastName).HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<DailyStoreRecord>(entity =>
            {
                entity.Property(e => e.CompanyKey).IsUnicode(false);

                entity.Property(e => e.ProdId).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CompanyKey).IsUnicode(false);

                entity.Property(e => e.Department).IsUnicode(false);

                entity.Property(e => e.ProdCategory).IsUnicode(false);

                entity.Property(e => e.ProdId).IsUnicode(false);

                entity.Property(e => e.ProdName).IsUnicode(false);

                entity.Property(e => e.UnitOfMeasure).IsUnicode(false);
            });

            modelBuilder.Entity<SalesItem>(entity =>
            {
                entity.Property(e => e.CompanyKey).IsUnicode(false);

                entity.Property(e => e.ProdId).IsUnicode(false);
            });

            modelBuilder.Entity<SalesMaster>(entity =>
            {
                entity.Property(e => e.CompanyKey).IsUnicode(false);

                entity.Property(e => e.CustomerId).IsUnicode(false);

                entity.Property(e => e.Department).IsUnicode(false);

                entity.Property(e => e.PaymentType).IsUnicode(false);

                entity.Property(e => e.StaffId).IsUnicode(false);

                entity.Property(e => e.Tcost).IsUnicode(false);
            });

            modelBuilder.Entity<StockKeeping>(entity =>
            {
                entity.Property(e => e.CompanyKey).IsUnicode(false);

                entity.Property(e => e.ProdId).IsUnicode(false);
            });

            modelBuilder.Entity<StoreRecord>(entity =>
            {
                entity.Property(e => e.AddedBy).IsUnicode(false);

                entity.Property(e => e.CompanyKey).IsUnicode(false);

                entity.Property(e => e.ProdId).IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.CompanyKey).IsUnicode(false);

                entity.Property(e => e.CompanyName).IsUnicode(false);

                entity.Property(e => e.ContactAddress).IsUnicode(false);

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.FullName).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);
            });

            modelBuilder.Entity<SupplyRecord>(entity =>
            {
                entity.Property(e => e.CompanyKey).IsUnicode(false);

                entity.Property(e => e.EnteredBy).IsUnicode(false);

                entity.Property(e => e.ProdId).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
            throw new InvalidOperationException("User ID must be provided");
        }

        public Task<int> SaveChanges(string userId, string Ip)
        {
            try
            {
                //TODO

                // Call the original SaveChanges(), which will save both the changes made and the audit records
                return base.SaveChangesAsync();
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}
