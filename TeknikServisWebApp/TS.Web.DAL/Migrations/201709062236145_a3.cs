namespace TS.Web.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArizaKaydiDetaylari", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ArizaKaydiDetaylari", "ApplicationUser_Id");
            AddForeignKey("dbo.ArizaKaydiDetaylari", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArizaKaydiDetaylari", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ArizaKaydiDetaylari", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ArizaKaydiDetaylari", "ApplicationUser_Id");
        }
    }
}
