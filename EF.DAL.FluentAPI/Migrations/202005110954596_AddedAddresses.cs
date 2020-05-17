namespace EF.DAL.FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAddresses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        Pincode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Employees", t => t.AddressId)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "AddressId", "dbo.Employees");
            DropIndex("dbo.Addresses", new[] { "AddressId" });
            DropTable("dbo.Addresses");
        }
    }
}
