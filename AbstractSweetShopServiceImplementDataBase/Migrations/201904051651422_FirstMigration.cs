namespace AbstractSweetShopServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuyerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuyerId = c.Int(nullable: false),
                        CandyId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .ForeignKey("dbo.Candies", t => t.CandyId, cascadeDelete: true)
                .Index(t => t.BuyerId)
                .Index(t => t.CandyId);
            
            CreateTable(
                "dbo.Candies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandyName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CandyMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandyId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        MaterialName = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candies", t => t.CandyId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.CandyId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CandyId", "dbo.Candies");
            DropForeignKey("dbo.StoreMaterials", "MaterialId", "dbo.Stores");
            DropForeignKey("dbo.StoreMaterials", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.CandyMaterials", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.CandyMaterials", "CandyId", "dbo.Candies");
            DropForeignKey("dbo.Jobs", "BuyerId", "dbo.Buyers");
            DropIndex("dbo.StoreMaterials", new[] { "MaterialId" });
            DropIndex("dbo.CandyMaterials", new[] { "MaterialId" });
            DropIndex("dbo.CandyMaterials", new[] { "CandyId" });
            DropIndex("dbo.Jobs", new[] { "CandyId" });
            DropIndex("dbo.Jobs", new[] { "BuyerId" });
            DropTable("dbo.Stores");
            DropTable("dbo.StoreMaterials");
            DropTable("dbo.Materials");
            DropTable("dbo.CandyMaterials");
            DropTable("dbo.Candies");
            DropTable("dbo.Jobs");
            DropTable("dbo.Buyers");
        }
    }
}
