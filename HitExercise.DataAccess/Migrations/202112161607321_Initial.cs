namespace HitExercise.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        CategoryId = c.Int(nullable: false),
                        Afm = c.String(nullable: false),
                        Address = c.String(maxLength: 100),
                        Telephone = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        CountryId = c.Int(nullable: false),
                        Inactive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SupplierCategories", t => t.CategoryId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.Name)
                .Index(t => t.CategoryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.SupplierCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Suppliers", "CategoryId", "dbo.SupplierCategories");
            DropIndex("dbo.Suppliers", new[] { "CountryId" });
            DropIndex("dbo.Suppliers", new[] { "CategoryId" });
            DropIndex("dbo.Suppliers", new[] { "Name" });
            DropTable("dbo.SupplierCategories");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Countries");
        }
    }
}
