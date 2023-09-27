using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pointify.DataTier.Models
{
    public partial class PromotionEngineContext : DbContext
    {
        public PromotionEngineContext()
        {
        }

        public PromotionEngineContext(DbContextOptions<PromotionEngineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Action> Actions { get; set; } = null!;
        public virtual DbSet<ActionProductMapping> ActionProductMappings { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Channel> Channels { get; set; } = null!;
        public virtual DbSet<ConditionGroup> ConditionGroups { get; set; } = null!;
        public virtual DbSet<ConditionRule> ConditionRules { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<GameCampaign> GameCampaigns { get; set; } = null!;
        public virtual DbSet<GameItem> GameItems { get; set; } = null!;
        public virtual DbSet<GameMaster> GameMasters { get; set; } = null!;
        public virtual DbSet<Gift> Gifts { get; set; } = null!;
        public virtual DbSet<GiftProductMapping> GiftProductMappings { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<MemberAction> MemberActions { get; set; } = null!;
        public virtual DbSet<MemberActionType> MemberActionTypes { get; set; } = null!;
        public virtual DbSet<MemberLevel> MemberLevels { get; set; } = null!;
        public virtual DbSet<MemberLevelMapping> MemberLevelMappings { get; set; } = null!;
        public virtual DbSet<MemberWallet> MemberWallets { get; set; } = null!;
        public virtual DbSet<Membership> Memberships { get; set; } = null!;
        public virtual DbSet<MembershipCard> MembershipCards { get; set; } = null!;
        public virtual DbSet<MembershipCardType> MembershipCardTypes { get; set; } = null!;
        public virtual DbSet<MembershipLevel> MembershipLevels { get; set; } = null!;
        public virtual DbSet<MembershipProgram> MembershipPrograms { get; set; } = null!;
        public virtual DbSet<OrderCondition> OrderConditions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductCondition> ProductConditions { get; set; } = null!;
        public virtual DbSet<ProductConditionMapping> ProductConditionMappings { get; set; } = null!;
        public virtual DbSet<Promotion> Promotions { get; set; } = null!;
        public virtual DbSet<PromotionChannelMapping> PromotionChannelMappings { get; set; } = null!;
        public virtual DbSet<PromotionStoreMapping> PromotionStoreMappings { get; set; } = null!;
        public virtual DbSet<PromotionTier> PromotionTiers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<StoreGameCampaignMapping> StoreGameCampaignMappings { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;
        public virtual DbSet<VoucherGroup> VoucherGroups { get; set; } = null!;
        public virtual DbSet<VoucherWallet> VoucherWallets { get; set; } = null!;
        public virtual DbSet<WalletType> WalletTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=120.72.85.82,9033;Database=PromotionEngine;User Id=sa;Password=f0^wyhMfl*25;Encrypt=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK_Account_1");

                entity.ToTable("Account");

                entity.Property(e => e.Username)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(62)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Account_Brand");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("Action");

                entity.Property(e => e.ActionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BundlePrice).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FixedPrice).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LadderPrice).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.MaxAmount).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.MinPriceAfter).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Action_Brand");
            });

            modelBuilder.Entity<ActionProductMapping>(entity =>
            {
                entity.ToTable("ActionProductMapping");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ActionProductMappings)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionProductMapping_Action");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ActionProductMappings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionProductMapping_Product");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.HasIndex(e => e.BrandCode, "Brand_UN")
                    .IsUnique();

                entity.Property(e => e.BrandId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.BrandCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BrandEmail)
                    .HasMaxLength(62)
                    .IsUnicode(false);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.ToTable("Channel");

                entity.Property(e => e.ChannelId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ApiKey)
                    .HasMaxLength(44)
                    .IsUnicode(false);

                entity.Property(e => e.ChannelCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ChannelName).HasMaxLength(50);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PrivateKey)
                    .HasMaxLength(2240)
                    .IsUnicode(false);

                entity.Property(e => e.PublicKey)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Channels)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Channel_Brand");
            });

            modelBuilder.Entity<ConditionGroup>(entity =>
            {
                entity.ToTable("ConditionGroup");

                entity.Property(e => e.ConditionGroupId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Summary).HasMaxLength(4000);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ConditionRule)
                    .WithMany(p => p.ConditionGroups)
                    .HasForeignKey(d => d.ConditionRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConditionGroup_ConditionRule");
            });

            modelBuilder.Entity<ConditionRule>(entity =>
            {
                entity.ToTable("ConditionRule");

                entity.Property(e => e.ConditionRuleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RuleName).HasMaxLength(50);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ConditionRules)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConditionRule_Brand");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FinishDate).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Brand");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device");

                entity.Property(e => e.DeviceId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_Store");
            });

            modelBuilder.Entity<GameCampaign>(entity =>
            {
                entity.ToTable("GameCampaign");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.EndGame).HasColumnType("datetime");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SecretCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.StartGame).HasColumnType("datetime");

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.GameCampaigns)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Game_Brand");

                entity.HasOne(d => d.GameMaster)
                    .WithMany(p => p.GameCampaigns)
                    .HasForeignKey(d => d.GameMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameConfig_GameMaster");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.GameCampaigns)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK_GameCampaign_Promotion");
            });

            modelBuilder.Entity<GameItem>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.DisplayText).HasMaxLength(30);

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Priority).HasDefaultValueSql("((1))");

                entity.Property(e => e.TextColor)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameItems)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameItems_Game");
            });

            modelBuilder.Entity<GameMaster>(entity =>
            {
                entity.ToTable("GameMaster");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Gift>(entity =>
            {
                entity.ToTable("Gift");

                entity.Property(e => e.GiftId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BonusPoint).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Gifts)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_PostAction_Brand");

                entity.HasOne(d => d.GameCampaign)
                    .WithMany(p => p.Gifts)
                    .HasForeignKey(d => d.GameCampaignId)
                    .HasConstraintName("FK_PostAction_GameCampaign");
            });

            modelBuilder.Entity<GiftProductMapping>(entity =>
            {
                entity.ToTable("GiftProductMapping");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Gift)
                    .WithMany(p => p.GiftProductMappings)
                    .HasForeignKey(d => d.GiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostActionProductMapping_PostAction");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.GiftProductMappings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostActionProductMapping_Product");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Member_Customer");

                entity.HasOne(d => d.MemberProgram)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.MemberProgramId)
                    .HasConstraintName("FK_Member_MembershipProgram");
            });

            modelBuilder.Entity<MemberAction>(entity =>
            {
                entity.ToTable("MemberAction");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ActionValue).HasColumnType("money");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.MemberActionType)
                    .WithMany(p => p.MemberActions)
                    .HasForeignKey(d => d.MemberActionTypeId)
                    .HasConstraintName("FK_MemberAction_MemberActionType");

                entity.HasOne(d => d.MemberShipCard)
                    .WithMany(p => p.MemberActions)
                    .HasForeignKey(d => d.MemberShipCardId)
                    .HasConstraintName("FK_MemberAction_MemberShipCard");

                entity.HasOne(d => d.MemberWallet)
                    .WithMany(p => p.MemberActions)
                    .HasForeignKey(d => d.MemberWalletId)
                    .HasConstraintName("FK_MemberAction_MemberWallet");
            });

            modelBuilder.Entity<MemberActionType>(entity =>
            {
                entity.ToTable("MemberActionType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.MemberShipProgram)
                    .WithMany(p => p.MemberActionTypes)
                    .HasForeignKey(d => d.MemberShipProgramId)
                    .HasConstraintName("FK_MemberActionType_MembershipProgram");
            });

            modelBuilder.Entity<MemberLevel>(entity =>
            {
                entity.ToTable("MemberLevel");

                entity.Property(e => e.MemberLevelId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.MemberLevels)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberLevel_Brand");
            });

            modelBuilder.Entity<MemberLevelMapping>(entity =>
            {
                entity.ToTable("MemberLevelMapping");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MemberLevel)
                    .WithMany(p => p.MemberLevelMappings)
                    .HasForeignKey(d => d.MemberLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberLevelMapping_MemberLevel");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.MemberLevelMappings)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberLevelMapping_Promotion");
            });

            modelBuilder.Entity<MemberWallet>(entity =>
            {
                entity.ToTable("MemberWallet");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberWallets)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_MemberWallet_Member");

                entity.HasOne(d => d.WalletType)
                    .WithMany(p => p.MemberWallets)
                    .HasForeignKey(d => d.WalletTypeId)
                    .HasConstraintName("FK_MemberWallet_WalletType");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.ToTable("Membership");

                entity.Property(e => e.MembershipId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .HasMaxLength(62)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname).HasMaxLength(50);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MembershipCard>(entity =>
            {
                entity.ToTable("MembershipCard");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.MembershipCardCode).HasMaxLength(50);

                entity.Property(e => e.PhysicalCardCode).HasMaxLength(50);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MembershipCards)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberShipCard_Member");

                entity.HasOne(d => d.MembershipCardType)
                    .WithMany(p => p.MembershipCards)
                    .HasForeignKey(d => d.MembershipCardTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberShipCard_MemberShipCardType");
            });

            modelBuilder.Entity<MembershipCardType>(entity =>
            {
                entity.ToTable("MembershipCardType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.MemberShipProgram)
                    .WithMany(p => p.MembershipCardTypes)
                    .HasForeignKey(d => d.MemberShipProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberShipCardType_MembershipProgram");
            });

            modelBuilder.Entity<MembershipLevel>(entity =>
            {
                entity.ToTable("MembershipLevel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.MembershipCard)
                    .WithMany(p => p.MembershipLevels)
                    .HasForeignKey(d => d.MembershipCardId)
                    .HasConstraintName("FK_MembershipLevel_MembershipCard");
            });

            modelBuilder.Entity<MembershipProgram>(entity =>
            {
                entity.ToTable("MembershipProgram");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDay).HasColumnType("datetime");

                entity.Property(e => e.StartDay).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermAndConditions).HasMaxLength(50);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.MembershipPrograms)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembershipProgram_Brand");
            });

            modelBuilder.Entity<OrderCondition>(entity =>
            {
                entity.ToTable("OrderCondition");

                entity.Property(e => e.OrderConditionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.AmountOperator)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuantityOperator)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ConditionGroup)
                    .WithMany(p => p.OrderConditions)
                    .HasForeignKey(d => d.ConditionGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderCondition_ConditionGroup1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(80);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ProductCate)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductCategory");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.ProductCateId);

                entity.ToTable("ProductCategory");

                entity.Property(e => e.ProductCateId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CateId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCategory_Brand");
            });

            modelBuilder.Entity<ProductCondition>(entity =>
            {
                entity.ToTable("ProductCondition");

                entity.Property(e => e.ProductConditionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.QuantityOperator)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ConditionGroup)
                    .WithMany(p => p.ProductConditions)
                    .HasForeignKey(d => d.ConditionGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCondition_ConditionGroup");
            });

            modelBuilder.Entity<ProductConditionMapping>(entity =>
            {
                entity.ToTable("ProductConditionMapping");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ProductCondition)
                    .WithMany(p => p.ProductConditionMappings)
                    .HasForeignKey(d => d.ProductConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductConditionMapping_ProductCondition");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductConditionMappings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductConditionMapping_Product");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("Promotion");

                entity.Property(e => e.PromotionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PromotionCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PromotionName).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Promotion_Brand");
            });

            modelBuilder.Entity<PromotionChannelMapping>(entity =>
            {
                entity.HasKey(e => e.PromotionChannelId)
                    .HasName("PK_VoucherChannel");

                entity.ToTable("PromotionChannelMapping");

                entity.Property(e => e.PromotionChannelId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.PromotionChannelMappings)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoucherChannel_Channel");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionChannelMappings)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionChannelMapping_Promotion");
            });

            modelBuilder.Entity<PromotionStoreMapping>(entity =>
            {
                entity.ToTable("PromotionStoreMapping");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionStoreMappings)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionStoreMapping_Promotion");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.PromotionStoreMappings)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionStoreMapping_Store");
            });

            modelBuilder.Entity<PromotionTier>(entity =>
            {
                entity.ToTable("PromotionTier");

                entity.Property(e => e.PromotionTierId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductCode).HasMaxLength(50);

                entity.Property(e => e.Summary).HasMaxLength(4000);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.PromotionTiers)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("FK_Action_PromotionTier");

                entity.HasOne(d => d.ConditionRule)
                    .WithMany(p => p.PromotionTiers)
                    .HasForeignKey(d => d.ConditionRuleId)
                    .HasConstraintName("FK_PromotionTier_ConditionRule");

                entity.HasOne(d => d.Gift)
                    .WithMany(p => p.PromotionTiers)
                    .HasForeignKey(d => d.GiftId)
                    .HasConstraintName("PromotionTier_FK");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionTiers)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK_PromotionTier_Promotion");

                entity.HasOne(d => d.VoucherGroup)
                    .WithMany(p => p.PromotionTiers)
                    .HasForeignKey(d => d.VoucherGroupId)
                    .HasConstraintName("FK_PromotionTier_VoucherGroup");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StoreName).HasMaxLength(50);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_Brand");
            });

            modelBuilder.Entity<StoreGameCampaignMapping>(entity =>
            {
                entity.HasKey(e => e.StoreGameCampaignId)
                    .HasName("StoreGameCampaignMapping_PK");

                entity.ToTable("StoreGameCampaignMapping");

                entity.Property(e => e.StoreGameCampaignId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.GameCampaign)
                    .WithMany(p => p.StoreGameCampaignMappings)
                    .HasForeignKey(d => d.GameCampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StoreGameCampaignMapping_FK_1");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreGameCampaignMappings)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StoreGameCampaignMapping_FK");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionJson).HasMaxLength(4000);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Transaction_Brand");

                entity.HasOne(d => d.MemberAction)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.MemberActionId)
                    .HasConstraintName("FK_Transaction_MemberAction");

                entity.HasOne(d => d.MemberWallet)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.MemberWalletId)
                    .HasConstraintName("FK_Transaction_MemberWallet");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => new { e.VoucherId, e.VoucherCode })
                    .HasName("PK_Voucher_1");

                entity.ToTable("Voucher");

                entity.Property(e => e.VoucherId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.VoucherCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RedempedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UsedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK_Voucher_Channel");

                entity.HasOne(d => d.GameCampaign)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.GameCampaignId)
                    .HasConstraintName("FK_Voucher_GameCampaign");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.MembershipId)
                    .HasConstraintName("FK_Voucher_Membership");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK_Voucher_Promotion");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Voucher_Store");

                entity.HasOne(d => d.VoucherGroup)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.VoucherGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Voucher_VoucherGroup");
            });

            modelBuilder.Entity<VoucherGroup>(entity =>
            {
                entity.ToTable("VoucherGroup");

                entity.Property(e => e.VoucherGroupId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Charset)
                    .HasMaxLength(42)
                    .IsUnicode(false);

                entity.Property(e => e.CustomCharset)
                    .HasMaxLength(106)
                    .IsUnicode(false);

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Postfix)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Prefix)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VoucherName).HasMaxLength(100);

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.VoucherGroups)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("FK_VoucherGroup_Action");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.VoucherGroups)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoucherGroup_Brand");

                entity.HasOne(d => d.Gift)
                    .WithMany(p => p.VoucherGroups)
                    .HasForeignKey(d => d.GiftId)
                    .HasConstraintName("FK_VoucherGroup_PostAction");
            });

            modelBuilder.Entity<VoucherWallet>(entity =>
            {
                entity.ToTable("VoucherWallet");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RedeemDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WalletType>(entity =>
            {
                entity.ToTable("WalletType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.MemberShipProgram)
                    .WithMany(p => p.WalletTypes)
                    .HasForeignKey(d => d.MemberShipProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WalletType_MembershipProgram");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
