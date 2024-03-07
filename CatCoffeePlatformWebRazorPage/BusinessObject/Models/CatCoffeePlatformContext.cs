using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class CatCoffeePlatformContext : DbContext
    {
        public CatCoffeePlatformContext()
        {
        }

        public CatCoffeePlatformContext(DbContextOptions<CatCoffeePlatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<AreaOfCat> AreaOfCats { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingDetail> BookingDetails { get; set; } = null!;
        public virtual DbSet<Cat> Cats { get; set; } = null!;
        public virtual DbSet<CatType> CatTypes { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Drink> Drinks { get; set; } = null!;
        public virtual DbSet<FoodForCat> FoodForCats { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<ShopCoffeeCat> ShopCoffeeCats { get; set; } = null!;
        public virtual DbSet<SlotBooking> SlotBookings { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:ContractsDB"];
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Address).HasMaxLength(30);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Role");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_ShopCoffeeCat_Account");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.AreaName)
                    .HasMaxLength(50)
                    .HasColumnName("areaName");

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Area_Account");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Area_ShopCoffeeCat");
            });

            modelBuilder.Entity<AreaOfCat>(entity =>
            {
                entity.ToTable("AreaOfCat");

                entity.Property(e => e.AreaOfCatId).HasColumnName("areaOfCatId");

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.CatId).HasColumnName("catId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.AreaOfCats)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_AreaOfCat_Area");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.AreaOfCats)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_AreaOfCat_Cat");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("bookingId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("date")
                    .HasColumnName("bookingDate");

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.SlotId).HasColumnName("slotId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TableId).HasColumnName("tableId");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Booking_Account");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_ShopCoffeeCat");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.SlotId)
                    .HasConstraintName("FK_Booking_SlotBooking");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK_Booking_Table");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.Property(e => e.BookingDetailId).HasColumnName("bookingDetailId");

                entity.Property(e => e.BookingId).HasColumnName("bookingId");

                entity.Property(e => e.DrinkId).HasColumnName("drinkId");

                entity.Property(e => e.FoodCatId).HasColumnName("foodCatId");

                entity.Property(e => e.NumberOfDrink).HasColumnName("numberOfDrink");

                entity.Property(e => e.NumberOfFoodCat).HasColumnName("numberOfFoodCat");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK_BookingDetails_Booking");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.DrinkId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BookingDetails_Drinks");

                entity.HasOne(d => d.FoodCat)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.FoodCatId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BookingDetails_FoodForCat");
            });

            modelBuilder.Entity<Cat>(entity =>
            {
                entity.ToTable("Cat");

                entity.Property(e => e.CatId).HasColumnName("catId");

                entity.Property(e => e.CatInfo)
                    .HasMaxLength(50)
                    .HasColumnName("catInfo");

                entity.Property(e => e.CatName)
                    .HasMaxLength(50)
                    .HasColumnName("catName");

                entity.Property(e => e.CatTypeId).HasColumnName("catTypeId");

                entity.Property(e => e.ImageCat)
                    .HasMaxLength(150)
                    .HasColumnName("imageCat");

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.CatType)
                    .WithMany(p => p.Cats)
                    .HasForeignKey(d => d.CatTypeId)
                    .HasConstraintName("FK_Cat_CatType");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Cats)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_Cat_ShopCoffeeCat");
            });

            modelBuilder.Entity<CatType>(entity =>
            {
                entity.ToTable("CatType");

                entity.Property(e => e.CatTypeId).HasColumnName("catTypeId");

                entity.Property(e => e.CatTypeName)
                    .HasMaxLength(30)
                    .HasColumnName("catTypeName");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasColumnName("commentId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.Context)
                    .HasMaxLength(500)
                    .HasColumnName("context");

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.Property(e => e.DrinkId).HasColumnName("drinkId");

                entity.Property(e => e.DinkInfo)
                    .HasMaxLength(50)
                    .HasColumnName("dinkInfo");

                entity.Property(e => e.DrinkName)
                    .HasMaxLength(30)
                    .HasColumnName("drinkName");

                entity.Property(e => e.ImageDrink)
                    .HasMaxLength(150)
                    .HasColumnName("imageDrink");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Drinks)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_Drink_ShopCoffeeCat");
            });

            modelBuilder.Entity<FoodForCat>(entity =>
            {
                entity.HasKey(e => e.FoodCatId);

                entity.ToTable("FoodForCat");

                entity.Property(e => e.FoodCatId).HasColumnName("foodCatId");

                entity.Property(e => e.FoodCatInfo)
                    .HasMaxLength(50)
                    .HasColumnName("foodCatInfo");

                entity.Property(e => e.FoodCatName)
                    .HasMaxLength(30)
                    .HasColumnName("foodCatName");

                entity.Property(e => e.FoodPrice).HasColumnName("foodPrice");

                entity.Property(e => e.ImageFoodForCat)
                    .HasMaxLength(150)
                    .HasColumnName("imageFoodForCat");

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.FoodForCats)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FoodForCat_ShopCoffeeCat");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.RateId);

                entity.ToTable("Rating");

                entity.Property(e => e.RateId).HasColumnName("rateId");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.RateNumber).HasColumnName("rateNumber");

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Account");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_ShopCoffeeCat");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(30)
                    .HasColumnName("roleName");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<ShopCoffeeCat>(entity =>
            {
                entity.HasKey(e => e.ShopId);

                entity.ToTable("ShopCoffeeCat");

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(15)
                    .HasColumnName("endTime");

                entity.Property(e => e.ImageShop)
                    .HasMaxLength(150)
                    .HasColumnName("imageShop");

                entity.Property(e => e.ShopName)
                    .HasMaxLength(50)
                    .HasColumnName("shopName");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(15)
                    .HasColumnName("startTime");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<SlotBooking>(entity =>
            {
                entity.HasKey(e => e.SlotId);

                entity.ToTable("SlotBooking");

                entity.Property(e => e.SlotId).HasColumnName("slotId");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(15)
                    .HasColumnName("endTime");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(15)
                    .HasColumnName("startTime");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.SlotBookings)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotBooking_ShopCoffeeCat");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table");

                entity.Property(e => e.TableId).HasColumnName("tableId");

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.ShopId).HasColumnName("shopId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .HasColumnName("tableName");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Table_Area");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_ShopCoffeeCat");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
