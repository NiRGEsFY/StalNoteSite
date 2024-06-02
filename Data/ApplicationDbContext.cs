using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StalNoteSite.Data.AuctionItem;
using StalNoteSite.Data.DataItem;
using StalNoteSite.Data.Other;
using StalNoteSite.Data.Users;

namespace StalNoteSite;

public partial class ApplicationDbContext : IdentityDbContext<User, Role, long>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AucItem> AucItems { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SelledItem> SelledItems { get; set; }

    public virtual DbSet<SqlItem> SqlItems { get; set; }
    public virtual DbSet<ArmorItem> ArmorsItems { get; set; }
    public virtual DbSet<Bullet> Bullets { get; set; }
    public virtual DbSet<WeaponItem> WeaponsItems { get; set; }
    public virtual DbSet<CaseItem> CaseItems { get; set; }
    public virtual DbSet<ArtefactItem> ArtefactItems { get; set; }

    public virtual DbSet<UserCase> UserCases { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Advertising> Advertisings { get; set; }
    public virtual DbSet<UserItem> UserItems { get; set; }
    public virtual DbSet<UserToken> UserTokens { get; set; }
    public virtual DbSet<UserTelegram> UserTelegrams { get; set; }





    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "data source=(localdb)\\MSSQLLocalDB;Initial Catalog=Stalcraft2;Integrated Security=True;MultipleActiveResultSets=True;"
            );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
