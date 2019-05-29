using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AngularAPI2_2.DbModels
{
    public partial class WebPOSContext : DbContext
    {
        public WebPOSContext()
        {
        }

        public WebPOSContext(DbContextOptions<WebPOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<FunctionButton> FunctionButton { get; set; }
        public virtual DbSet<FunctionGroup> FunctionGroup { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.20.11;Database=WebPOS;User Id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => new { e.ShopId, e.AreaId })
                    .HasName("PK_Area_1");

                entity.Property(e => e.ShopId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AreaId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<FunctionButton>(entity =>
            {
                entity.HasKey(e => new { e.FunctionGroupId, e.FunctionButtonId });

                entity.Property(e => e.BackgroundColor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BorderColor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DisplayText)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FontColor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Seq).HasDefaultValueSql("((100))");

                entity.Property(e => e.Visible)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<FunctionGroup>(entity =>
            {
                entity.Property(e => e.FunctionGroupId).ValueGeneratedNever();

                entity.Property(e => e.FunctionGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasKey(e => new { e.ShopId, e.TableId });

                entity.Property(e => e.ShopId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TableId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AreaId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Account);

                entity.Property(e => e.Account)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SetupTime).HasColumnType("datetime");

                entity.Property(e => e.ShopId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(10);
            });
        }
    }
}
