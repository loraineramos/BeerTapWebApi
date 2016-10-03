namespace BeerTapHypermediaWebApi.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KegOffices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KegOfficeId = c.String(),
                        KegOfficeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Kegs",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KegId = c.String(),
                        KegMl = c.Int(nullable: false),
                        Description = c.String(),
                        KegState = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kegs", "KegOffice_Id", "dbo.KegOffices");
            DropIndex("dbo.Kegs", new[] { "KegOffice_Id" });
            DropTable("dbo.Kegs");
            DropTable("dbo.KegOffices");
        }
    }
}
