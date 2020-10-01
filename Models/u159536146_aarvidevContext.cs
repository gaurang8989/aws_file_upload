using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace localstorage_to_s3bucket.Models
{
    public partial class u159536146_aarvidevContext : DbContext
    {
        public u159536146_aarvidevContext()
        {
        }

        public u159536146_aarvidevContext(DbContextOptions<u159536146_aarvidevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<LogHistory> LogHistory { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Pincode> Pincode { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Volvereexp> Volvereexp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.AddId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.PinId)
                    .HasName("Fk_pinId");

                entity.HasIndex(e => e.UserId)
                    .HasName("Fk_Address_User_Id");

                entity.Property(e => e.AddId)
                    .HasColumnName("Add_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AddressName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.HouseNo)
                    .IsRequired()
                    .HasColumnName("House_no.")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Landmark)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasColumnType("decimal(11,8)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Longitude)
                    .HasColumnType("decimal(10,8)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PinId)
                    .HasColumnName("Pin_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Society)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("User_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Pin)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.PinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_pinId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Address_User_Id");
            });

            modelBuilder.Entity<LogHistory>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("Log_History");

                entity.HasIndex(e => e.UserId)
                    .HasName("Fk_LogHistory_User_Id");

                entity.Property(e => e.LogId)
                    .HasColumnName("Log_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LoginDatetime).HasColumnName("Login_datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LogHistory)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Fk_LogHistory_User_Id");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.MobileNo)
                    .HasColumnName("Mobile_no")
                    .HasColumnType("bigint(10)");

                entity.Property(e => e.Verification).HasColumnType("int(1)");
            });

            modelBuilder.Entity<Pincode>(entity =>
            {
                entity.HasKey(e => e.PinId)
                    .HasName("PRIMARY");

                entity.Property(e => e.PinId)
                    .HasColumnName("Pin_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PincodeNo)
                    .HasColumnName("Pincode_no.")
                    .HasColumnType("int(6)");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("User_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreationDatetime)
                    .HasColumnName("Creation_datetime")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Gender)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Lname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MobileNo)
                    .HasColumnName("Mobile_no.")
                    .HasColumnType("bigint(10)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProfilePhoto)
                    .HasColumnName("Profile_photo")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Volvereexp>(entity =>
            {
                entity.ToTable("volvereexp");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImageLink)
                    .IsRequired()
                    .HasColumnName("image_link");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
