using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookYourMealAPI.Domain.Entities
{
    public partial class Orchard8Context : DbContext
    {
        public Orchard8Context()
        {
        }

        public Orchard8Context(DbContextOptions<Orchard8Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TblActiveUser> TblActiveUser { get; set; }
        public virtual DbSet<TblAddressDetails> TblAddressDetails { get; set; }
        public virtual DbSet<TblApprovalStatus> TblApprovalStatus { get; set; }
        public virtual DbSet<TblApprove> TblApprove { get; set; }
        public virtual DbSet<TblFavourite> TblFavourite { get; set; }
        public virtual DbSet<TblItemCategoryDetails> TblItemCategoryDetails { get; set; }
        public virtual DbSet<TblItemDetails> TblItemDetails { get; set; }
        public virtual DbSet<TblItemTypeDetails> TblItemTypeDetails { get; set; }
        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblOrderDetails> TblOrderDetails { get; set; }
        public virtual DbSet<TblRestaurantAvailability> TblRestaurantAvailability { get; set; }
        public virtual DbSet<TblRestaurantDetails> TblRestaurantDetails { get; set; }
        public virtual DbSet<TblReview> TblReview { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblUserDetails> TblUserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=orchardsqlserver.database.windows.net;Database=Orchard8;User id=Sqluser8;Password=pwd#Login8");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblActiveUser>(entity =>
            {
                entity.HasKey(e => e.ActiveUserId);

                entity.ToTable("tblActiveUser");

                entity.Property(e => e.ActiveUserId).HasColumnName("activeUserId");

                entity.Property(e => e.ActiveUser)
                    .IsRequired()
                    .HasColumnName("activeUser")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAddressDetails>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.ToTable("tblAddressDetails");

                entity.Property(e => e.AddressId)
                    .HasColumnName("addressId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblAddressDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tblAddres__userI__2DB1C7EE");
            });

            modelBuilder.Entity<TblApprovalStatus>(entity =>
            {
                entity.HasKey(e => e.ApprovalStatusId);

                entity.ToTable("tblApprovalStatus");

                entity.Property(e => e.ApprovalStatusId).HasColumnName("approvalStatusId");

                entity.Property(e => e.ApprovalStatus)
                    .IsRequired()
                    .HasColumnName("approvalStatus")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblApprove>(entity =>
            {
                entity.HasKey(e => e.ApproveId);

                entity.ToTable("tblApprove");

                entity.Property(e => e.ApproveId).HasColumnName("approveId");

                entity.Property(e => e.ApprovalStatusId).HasColumnName("approvalStatusId");

                entity.Property(e => e.RestaurantName)
                    .HasColumnName("restaurantName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.TblApprove)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblApprov__appro__1E6F845E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblApprove)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tblApprov__userI__1D7B6025");
            });

            modelBuilder.Entity<TblFavourite>(entity =>
            {
                entity.HasKey(e => e.FavouriteId);

                entity.ToTable("tblFavourite");

                entity.Property(e => e.FavouriteId).HasColumnName("favouriteId");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurantId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.TblFavourite)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblFavour__resta__2AD55B43");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblFavourite)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblFavour__userI__29E1370A");
            });

            modelBuilder.Entity<TblItemCategoryDetails>(entity =>
            {
                entity.HasKey(e => e.ItemCategoryId);

                entity.ToTable("tblItemCategoryDetails");

                entity.Property(e => e.ItemCategoryId).HasColumnName("itemCategoryId");

                entity.Property(e => e.ItemCategoryName)
                    .IsRequired()
                    .HasColumnName("itemCategoryName")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblItemDetails>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("tblItemDetails");

                entity.Property(e => e.ItemId)
                    .HasColumnName("itemId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemCategoryId).HasColumnName("itemCategoryId");

                entity.Property(e => e.ItemImage)
                    .HasColumnName("itemImage")
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("itemName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnName("itemPrice");

                entity.Property(e => e.ItemTypeId).HasColumnName("itemTypeId");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurantId");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.TblItemDetails)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FK__tblItemDe__itemC__382F5661");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.TblItemDetails)
                    .HasForeignKey(d => d.ItemTypeId)
                    .HasConstraintName("FK__tblItemDe__itemT__373B3228");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.TblItemDetails)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK__tblItemDe__resta__36470DEF");
            });

            modelBuilder.Entity<TblItemTypeDetails>(entity =>
            {
                entity.HasKey(e => e.ItemTypeId);

                entity.ToTable("tblItemTypeDetails");

                entity.Property(e => e.ItemTypeId).HasColumnName("itemTypeId");

                entity.Property(e => e.ItemTypeName)
                    .IsRequired()
                    .HasColumnName("itemTypeName")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("tblOrder");

                entity.Property(e => e.OrderId)
                    .HasColumnName("orderId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressId).HasColumnName("addressId");

                entity.Property(e => e.OrderDtstamp)
                    .HasColumnName("orderDtstamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurantId");

                entity.Property(e => e.TotalCost).HasColumnName("totalCost");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrder__addres__336AA144");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrder__restau__318258D2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrder__userId__308E3499");
            });

            modelBuilder.Entity<TblOrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId);

                entity.ToTable("tblOrderDetails");

                entity.Property(e => e.OrderDetailsId)
                    .HasColumnName("orderDetailsId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblOrderDetails)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrderD__itemI__3BFFE745");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TblOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrderD__order__3B0BC30C");
            });

            modelBuilder.Entity<TblRestaurantAvailability>(entity =>
            {
                entity.HasKey(e => e.RestaurantAvailabilityId);

                entity.ToTable("tblRestaurantAvailability");

                entity.Property(e => e.RestaurantAvailability)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRestaurantDetails>(entity =>
            {
                entity.HasKey(e => e.RestaurantId);

                entity.ToTable("tblRestaurantDetails");

                entity.Property(e => e.RestaurantId)
                    .HasColumnName("restaurantId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApproveId).HasColumnName("approveId");

                entity.Property(e => e.Discounts)
                    .HasColumnName("discounts")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RestaurantAvailabilityId).HasColumnName("restaurantAvailabilityId");

                entity.Property(e => e.RestaurantImageUrl)
                    .HasColumnName("restaurantImageUrl")
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Approve)
                    .WithMany(p => p.TblRestaurantDetails)
                    .HasForeignKey(d => d.ApproveId)
                    .HasConstraintName("FK__tblRestau__appro__251C81ED");

                entity.HasOne(d => d.RestaurantAvailability)
                    .WithMany(p => p.TblRestaurantDetails)
                    .HasForeignKey(d => d.RestaurantAvailabilityId)
                    .HasConstraintName("FK__tblRestau__resta__2704CA5F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblRestaurantDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tblRestau__userI__24285DB4");
            });

            modelBuilder.Entity<TblReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId);

                entity.ToTable("tblReview");

                entity.Property(e => e.ReviewId)
                    .HasColumnName("reviewId")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TblReview)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblReview__order__3FD07829");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblReview)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblReview__userI__3EDC53F0");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("tblRole");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("roleName")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUserDetails>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblUserDetails");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActiveUserId).HasColumnName("activeUserId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(18, 8)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl)
                    .HasColumnName("photoUrl")
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.SignupDtstamp)
                    .HasColumnName("signupDtstamp")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserMobile).HasColumnName("userMobile");

                entity.Property(e => e.WalletBalance)
                    .HasColumnName("walletBalance")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ActiveUser)
                    .WithMany(p => p.TblUserDetails)
                    .HasForeignKey(d => d.ActiveUserId)
                    .HasConstraintName("FK__tblUserDe__activ__214BF109");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUserDetails)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUserDe__roleI__16CE6296");
            });
        }
    }
}
