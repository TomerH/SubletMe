namespace SubletMe.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Request : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Rooms = c.String(),
                        UserId = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        State = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Floor = c.String(),
                        ApartmentNumber = c.String(),
                        Description = c.String(),
                        Accessories = c.String(),
                        AirConditioner = c.String(),
                        Balcony = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Requests");
        }
    }
}
