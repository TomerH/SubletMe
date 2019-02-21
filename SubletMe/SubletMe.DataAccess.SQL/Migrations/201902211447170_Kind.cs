namespace SubletMe.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kind : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "Kind", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "Kind");
        }
    }
}
