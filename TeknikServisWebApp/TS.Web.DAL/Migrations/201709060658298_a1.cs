namespace TS.Web.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArizaKaydiDetaylari",
                c => new
                    {
                        ArizaKaydiDetayId = c.Int(nullable: false, identity: true),
                        ArizaKaydiId = c.Int(nullable: false),
                        OprIslemZamani = c.DateTime(nullable: false),
                        OprOnayladiMi = c.Boolean(nullable: false),
                        OprAciklamasi = c.String(maxLength: 200),
                        TeknikerRaporu = c.String(maxLength: 200),
                        Fiyat = c.Decimal(nullable: false, precision: 7, scale: 2),
                        BitirmeZamani = c.DateTime(nullable: false),
                        OperatorId = c.String(maxLength: 128),
                        TeknikerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ArizaKaydiDetayId)
                .ForeignKey("dbo.AspNetUsers", t => t.OperatorId)
                .ForeignKey("dbo.AspNetUsers", t => t.TeknikerId)
                .Index(t => t.OperatorId)
                .Index(t => t.TeknikerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Name = c.String(nullable: false, maxLength: 25),
                        Surname = c.String(nullable: false, maxLength: 35),
                        RegisterDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        ActivationCode = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ArizaKayitlari",
                c => new
                    {
                        ArizaKaydiId = c.Int(nullable: false, identity: true),
                        KategoriId = c.Int(nullable: false),
                        Aciklama = c.String(maxLength: 200),
                        ArizaFotografYolu = c.String(),
                        Konumu = c.String(maxLength: 50),
                        Adres = c.String(maxLength: 200),
                        Puan = c.Int(nullable: false),
                        ArizaGiderildiMi = c.Boolean(nullable: false),
                        OlusturulmaZamani = c.DateTime(nullable: false),
                        MusteriId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ArizaKaydiId)
                .ForeignKey("dbo.Kategoriler", t => t.KategoriId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.MusteriId)
                .Index(t => t.KategoriId)
                .Index(t => t.MusteriId);
            
            CreateTable(
                "dbo.Kategoriler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false, maxLength: 100),
                        Aciklama = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.KategoriAdi, unique: true);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 200),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ArizaKayitlari", "MusteriId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ArizaKayitlari", "KategoriId", "dbo.Kategoriler");
            DropForeignKey("dbo.ArizaKaydiDetaylari", "TeknikerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ArizaKaydiDetaylari", "OperatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Kategoriler", new[] { "KategoriAdi" });
            DropIndex("dbo.ArizaKayitlari", new[] { "MusteriId" });
            DropIndex("dbo.ArizaKayitlari", new[] { "KategoriId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "UserName" });
            DropIndex("dbo.AspNetUsers", new[] { "Email" });
            DropIndex("dbo.ArizaKaydiDetaylari", new[] { "TeknikerId" });
            DropIndex("dbo.ArizaKaydiDetaylari", new[] { "OperatorId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Kategoriler");
            DropTable("dbo.ArizaKayitlari");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ArizaKaydiDetaylari");
        }
    }
}
