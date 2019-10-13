using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CommerceBank.Models.Database
{
    public partial class CCG4DbEntities : DbContext
    {

        public CCG4DbEntities(DbContextOptions<CCG4DbEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<BusinessRules> BusinessRules { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<TestTable> TestTable { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\CCG4;Database=CCG4;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Accounts_Accounts");
            });

            modelBuilder.Entity<BusinessRules>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountId).IsFixedLength();

                entity.Property(e => e.RuleConstraints).IsFixedLength();

                entity.Property(e => e.RuleName).IsFixedLength();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsFixedLength();

                entity.Property(e => e.LastName).IsFixedLength();
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.Property(e => e.UserName).IsFixedLength();

                entity.Property(e => e.Password).IsFixedLength();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Logins_Logins");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.TransactionId).ValueGeneratedNever();

                entity.Property(e => e.Dispute).IsFixedLength();

                entity.Property(e => e.TransactionAmount).IsFixedLength();

                entity.Property(e => e.TransactionDetails).IsFixedLength();

                entity.Property(e => e.TransactionType).IsFixedLength();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Transactions_Accounts");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

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
