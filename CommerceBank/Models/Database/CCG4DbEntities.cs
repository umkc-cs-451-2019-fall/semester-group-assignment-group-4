using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CommerceBank.Models.Database
{
    public partial class CCG4DbEntities : DbContext
    {
        public CCG4DbEntities()
        {
        }

        public CCG4DbEntities(DbContextOptions<CCG4DbEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<BusinessRules> BusinessRules { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\CCG4; Database=CCG4; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.AccountId).ValueGeneratedNever();
            });

            modelBuilder.Entity<BusinessRules>(entity =>
            {
                entity.Property(e => e.RuleId).ValueGeneratedNever();

                entity.Property(e => e.AccountId).IsFixedLength();

                entity.Property(e => e.RuleConstraints).IsFixedLength();

                entity.Property(e => e.RuleName).IsFixedLength();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ClientType).IsFixedLength();
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Password).IsFixedLength();

                entity.Property(e => e.UserName).IsFixedLength();
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.AccountBalance).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TransactionAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TransactionDate).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.TransactionDescription).HasDefaultValueSql("(N'None')");

                entity.Property(e => e.TransactionLocation).HasDefaultValueSql("(N'Unknown')");

                entity.Property(e => e.TransactionTime).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.TransactionType).HasDefaultValueSql("(N'WD')");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FirstName).IsFixedLength();

                entity.Property(e => e.LastName).IsFixedLength();

                entity.Property(e => e.UserName).IsFixedLength();

                entity.Property(e => e.UserPass).IsFixedLength();

                entity.Property(e => e.UserRights).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
