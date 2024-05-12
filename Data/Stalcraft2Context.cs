using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StalNoteSite.Data.AuctionItem;
using StalNoteSite.Data.DataItem;
using StalNoteSite.Data.Other;
using StalNoteSite.Data.Users;

namespace StalNoteSite;

public partial class Stalcraft2Context : DbContext
{
    public Stalcraft2Context()
    {
    }

    public Stalcraft2Context(DbContextOptions<Stalcraft2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Advertising> Advertisings { get; set; }

    public virtual DbSet<ArmorItem> ArmorsItems { get; set; }

    public virtual DbSet<ArtefactItem> ArtefactItems { get; set; }

    public virtual DbSet<AucItem> AucItems { get; set; }

    public virtual DbSet<Bullet> Bullets { get; set; }

    public virtual DbSet<CaseItem> CaseItems { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SelledItem> SelledItems { get; set; }

    public virtual DbSet<SqlItem> SqlItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserConfig> UserConfigs { get; set; }

    public virtual DbSet<UserItem> UserItems { get; set; }

    public virtual DbSet<UserTelegram> UserTelegrams { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }

    public virtual DbSet<UserCase> UserCases { get; set; }

    public virtual DbSet<WeaponItem> WeaponsItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "data source=(localdb)\\MSSQLLocalDB;Initial Catalog=Stalcraft2;Integrated Security=True;MultipleActiveResultSets=True;"
            );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArtefactItem>(entity =>
        {
            entity.Property(e => e.BioinfectionInfectionMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.BioinfectionInfectionMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.BioinfectionProtectionMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.BioinfectionProtectionMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.BioinfectionResistanceMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.BioinfectionResistanceMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.BleedingMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.BleedingMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.BulletResistanceMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.BulletResistanceMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.CarryWeightMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.CarryWeightMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.Category).HasMaxLength(30);
            entity.Property(e => e.ChargeRequiredToActivateMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.ChargeRequiredToActivateMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.ExplosionProtectionMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.ExplosionProtectionMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.FrostMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.FrostMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.HealingEffectivenessMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.HealingEffectivenessMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.HealthRegenerationMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.HealthRegenerationMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.ItemId).HasMaxLength(10);
            entity.Property(e => e.LacerationProtectionMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.LacerationProtectionMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PsyEmissionsMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.PsyEmissionsMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.PsyEmissionsProtectionMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.PsyEmissionsProtectionMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.PsyEmissionsResistanceMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.PsyEmissionsResistanceMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.RadiationMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.RadiationMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.RadiationProtectionMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.RadiationProtectionMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.RadiationResistanceMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.RadiationResistanceMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.ReactionToBurnsMax).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.ReactionToBurnsMin).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.SubType).HasMaxLength(30);
            entity.Property(e => e.Type).HasMaxLength(25);
        });

        modelBuilder.Entity<AucItem>(entity =>
        {
            entity.Property(e => e.ItemId)
                .HasMaxLength(20)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<Bullet>(entity =>
        {
            entity.Property(e => e.AmmoType).HasMaxLength(30);
            entity.Property(e => e.Class).HasMaxLength(30);
            entity.Property(e => e.Damage).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.ItemId).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NumberOfProjectiles).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.Spread).HasDefaultValueSql("((0.0000000000000000e+000))");
            entity.Property(e => e.SubType).HasMaxLength(30);
            entity.Property(e => e.Type).HasMaxLength(30);
        });

        modelBuilder.Entity<CaseItem>(entity =>
        {
            entity.Property(e => e.CaseType).HasMaxLength(50);
            entity.Property(e => e.Class).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ItemId).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rank).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<SelledItem>(entity =>
        {
            entity.Property(e => e.ItemId)
                .HasMaxLength(20)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<SqlItem>(entity =>
        {
            entity.Property(e => e.ItemId)
                .HasMaxLength(15)
                .HasDefaultValue("");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasDefaultValue("");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_Users_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<UserConfig>(entity =>
        {
            entity.ToTable("UserConfig");

            entity.HasIndex(e => e.UserId, "IX_UserConfig_UserId").IsUnique();

            entity.HasOne(d => d.User).WithOne(p => p.UserConfig).HasForeignKey<UserConfig>(d => d.UserId);
        });

        modelBuilder.Entity<UserItem>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_UserItems_UserId");

            entity.Property(e => e.ItemId)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValue("");

            entity.HasOne(d => d.User).WithMany(p => p.UserItems).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<UserTelegram>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_UserTelegrams_UserId").IsUnique();

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.User).WithOne(p => p.UserTelegram).HasForeignKey<UserTelegram>(d => d.UserId);
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_UserTokens_UserId").IsUnique();

            entity.Property(e => e.AccessCode).HasMaxLength(2000);
            entity.Property(e => e.AccessToken).HasMaxLength(2000);
            entity.Property(e => e.RefreshToken).HasMaxLength(2000);

            entity.HasOne(d => d.User).WithOne(p => p.UserToken).HasForeignKey<UserToken>(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
