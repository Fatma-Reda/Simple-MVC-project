namespace ITI.UI.MVC.Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Email = c.String(),
                        FK_depId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.FK_depId, cascadeDelete: true)
                .Index(t => t.FK_depId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "FK_depId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "FK_depId" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
