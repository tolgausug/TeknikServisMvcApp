using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using TS.Web.MODEL.IdentityModels;
using System.Data.Entity;
using TS.Web.MODEL.Entities;

namespace TS.Web.DAL
{
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext()
            : base("name=MyCon")
        { }

        public virtual DbSet<ArizaKaydi> ArizaKayitlari { get; set; }
        public virtual DbSet<ArizaKaydiDetay> ArizaKaydiDetaylari { get; set; }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API
            modelBuilder.Entity<ArizaKaydiDetay>()
                .Property(x => x.Fiyat)
                .HasPrecision(7, 2);
        }
    }
}
