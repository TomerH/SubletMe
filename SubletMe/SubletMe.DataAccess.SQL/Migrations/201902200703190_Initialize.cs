namespace SubletMe.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Floors = c.String(),
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
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Roommates = c.String(),
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
            DropTable("dbo.Rooms");
            DropTable("dbo.Apartments");
        }
    }
}
