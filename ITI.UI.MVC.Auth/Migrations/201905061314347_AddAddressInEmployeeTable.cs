namespace ITI.UI.MVC.Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressInEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Address");
        }
    }
}
