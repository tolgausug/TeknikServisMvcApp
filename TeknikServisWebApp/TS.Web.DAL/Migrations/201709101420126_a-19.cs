namespace TS.Web.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArizaKayitlari", "UrunFotografYolu", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArizaKayitlari", "UrunFotografYolu");
        }
    }
}
