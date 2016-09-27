namespace BeerTapHypermediaWebApi.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Keg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kegs", "KegOffice_Id", "dbo.KegOffices");
            DropIndex("dbo.Kegs", new[] { "KegOffice_Id" });
            AddColumn("dbo.KegOffices", "Keg_Id", c => c.Int());
            CreateIndex("dbo.KegOffices", "Keg_Id");
            AddForeignKey("dbo.KegOffices", "Keg_Id", "dbo.Kegs", "Id");
            DropColumn("dbo.Kegs", "KegOffice_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kegs", "KegOffice_Id", c => c.Int());
            DropForeignKey("dbo.KegOffices", "Keg_Id", "dbo.Kegs");
            DropIndex("dbo.KegOffices", new[] { "Keg_Id" });
            DropColumn("dbo.KegOffices", "Keg_Id");
            CreateIndex("dbo.Kegs", "KegOffice_Id");
            AddForeignKey("dbo.Kegs", "KegOffice_Id", "dbo.KegOffices", "Id");
        }
    }
}
