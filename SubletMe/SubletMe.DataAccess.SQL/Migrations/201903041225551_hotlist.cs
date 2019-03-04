namespace SubletMe.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotlist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "HotList", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rooms", "HotList", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "HotList");
            DropColumn("dbo.Apartments", "HotList");
        }
    }
}
