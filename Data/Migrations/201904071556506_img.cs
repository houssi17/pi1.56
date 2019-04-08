namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class img : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "img", c => c.String());
            DropColumn("dbo.User", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Path", c => c.String());
            DropColumn("dbo.User", "img");
        }
    }
}
