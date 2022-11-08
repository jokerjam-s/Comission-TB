using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ComissionTB.Models;
using Microsoft.AspNetCore.Identity;
using ComissionTB.ViewModels;

namespace ComissionTB.Data
{
    public class ComissionDbContext : IdentityDbContext<AppUsers, AppRoles, int>
    {
        public ComissionDbContext(DbContextOptions<ComissionDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // задание значений по умолчанию
            builder.Entity<Akt>().Property(a => a.aktDate).HasDefaultValueSql("GETDATE()");
            builder.Entity<Akt>().Property(a => a.SoglHave).HasDefaultValue(0);
            builder.Entity<Akt>().Property(a => a.SoglCnt).HasDefaultValue(0);

            // необходима уникальность значений
            builder.Entity<Cex>().HasIndex(c => c.cexName).IsUnique();
            builder.Entity<Dolgn>().HasIndex(d => d.dlName).IsUnique();
        }

        public DbSet<Akt> akt { get; set; }

        public DbSet<Cex> cex { get; set; }

        public DbSet<Dolgn> dolgn { get; set; }

        public DbSet<Predp> predp { get; set; }

        public DbSet<Sostav> sostav { get; set; }

        public DbSet<Pom> pom { get; set; }

        public DbSet<MailSettings> mailSetting { get; set; }

    }
}
