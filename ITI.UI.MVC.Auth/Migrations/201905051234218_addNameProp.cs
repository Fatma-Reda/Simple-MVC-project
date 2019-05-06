namespace ITI.UI.MVC.Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
