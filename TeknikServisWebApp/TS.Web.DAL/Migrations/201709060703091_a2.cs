namespace TS.Web.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ArizaKaydiDetaylari", "BitirmeZamani", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArizaKaydiDetaylari", "BitirmeZamani", c => c.DateTime(nullable: false));
        }
    }
}
