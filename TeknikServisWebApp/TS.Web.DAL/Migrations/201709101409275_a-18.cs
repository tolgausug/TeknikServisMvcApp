namespace TS.Web.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a18 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ArizaKayitlari", "ArizaFotografYolu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArizaKayitlari", "ArizaFotografYolu", c => c.String());
        }
    }
}
