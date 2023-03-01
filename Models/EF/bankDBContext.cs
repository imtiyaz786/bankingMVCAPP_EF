using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

#nullable disable

namespace bankingMVCApp_EF.Models.EF
{
    public partial class bankDBContext : DbContext
    {
        public bankDBContext()
        {
        }

        public bankDBContext(DbContextOptions<bankDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountsInfo> AccountsInfos { get; set; }
        public virtual DbSet<BranchInfo> BranchInfos { get; set; }
        public virtual DbSet<TransactionInfo> TransactionInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                string connectionString = configuration.GetConnectionString("BankDBConnection");
                optionsBuilder.UseSqlServer(connectionString);
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountsInfo>(entity =>
            {
                entity.HasKey(e => e.AccNo)
                    .HasName("PK__accounts__A4719705ECFE1069");

                entity.ToTable("accountsInfo");

                entity.Property(e => e.AccNo)
                    .ValueGeneratedNever()
                    .HasColumnName("accNo");

                entity.Property(e => e.AccBalance).HasColumnName("accBalance");

                entity.Property(e => e.AccBranch).HasColumnName("accBranch");

                entity.Property(e => e.AccName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("accName");

                entity.Property(e => e.AccType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("accType");

                entity.HasOne(d => d.AccBranchNavigation)
                    .WithMany(p => p.AccountsInfos)
                    .HasForeignKey(d => d.AccBranch)
                    .HasConstraintName("fk_accNo");
            });

            modelBuilder.Entity<BranchInfo>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("PK__branchIn__751EBD5F0E7965D1");

                entity.ToTable("branchInfo");

                entity.Property(e => e.BranchId)
                    .ValueGeneratedNever()
                    .HasColumnName("branchId");

                entity.Property(e => e.BranchCity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("branchCity");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("branchName");
            });

            modelBuilder.Entity<TransactionInfo>(entity =>
            {
                entity.HasKey(e => e.TrId)
                    .HasName("PK__transact__9C31E3927D7F88BB");

                entity.ToTable("transactionInfo");

                entity.Property(e => e.TrId)
                    .ValueGeneratedNever()
                    .HasColumnName("trId");

                entity.Property(e => e.TrAmount).HasColumnName("trAmount");

                entity.Property(e => e.TrFromAccount).HasColumnName("trFromAccount");

                entity.Property(e => e.TrToAccount).HasColumnName("trToAccount");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
