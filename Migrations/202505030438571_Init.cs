namespace Fitness_Tracking_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TblUsers");
        }
    }
}
