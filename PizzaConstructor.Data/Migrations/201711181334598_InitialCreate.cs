namespace PizzaConstructor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Phone = c.String(),
                        Name = c.String(),
                        DeliveryAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(),
                        ImageUrlMain = c.String(),
                        Category = c.Int(nullable: false),
                        Index = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PizzaItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Contact_Id = c.Guid(),
                        User_Email = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .ForeignKey("dbo.Users", t => t.User_Email, cascadeDelete: true)
                .Index(t => t.Contact_Id)
                .Index(t => t.User_Email);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.PizzaTemplates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PizzaItemIngredients",
                c => new
                    {
                        PizzaItem_Id = c.Guid(nullable: false),
                        Ingredient_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PizzaItem_Id, t.Ingredient_Id })
                .ForeignKey("dbo.PizzaItems", t => t.PizzaItem_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .Index(t => t.PizzaItem_Id)
                .Index(t => t.Ingredient_Id);
            
            CreateTable(
                "dbo.PizzaTemplateIngredients",
                c => new
                    {
                        PizzaTemplate_Id = c.Guid(nullable: false),
                        Ingredient_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PizzaTemplate_Id, t.Ingredient_Id })
                .ForeignKey("dbo.PizzaTemplates", t => t.PizzaTemplate_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .Index(t => t.PizzaTemplate_Id)
                .Index(t => t.Ingredient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PizzaTemplateIngredients", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.PizzaTemplateIngredients", "PizzaTemplate_Id", "dbo.PizzaTemplates");
            DropForeignKey("dbo.Orders", "User_Email", "dbo.Users");
            DropForeignKey("dbo.PizzaItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.PizzaItemIngredients", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.PizzaItemIngredients", "PizzaItem_Id", "dbo.PizzaItems");
            DropIndex("dbo.PizzaTemplateIngredients", new[] { "Ingredient_Id" });
            DropIndex("dbo.PizzaTemplateIngredients", new[] { "PizzaTemplate_Id" });
            DropIndex("dbo.PizzaItemIngredients", new[] { "Ingredient_Id" });
            DropIndex("dbo.PizzaItemIngredients", new[] { "PizzaItem_Id" });
            DropIndex("dbo.Orders", new[] { "User_Email" });
            DropIndex("dbo.Orders", new[] { "Contact_Id" });
            DropIndex("dbo.PizzaItems", new[] { "Order_Id" });
            DropTable("dbo.PizzaTemplateIngredients");
            DropTable("dbo.PizzaItemIngredients");
            DropTable("dbo.PizzaTemplates");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.PizzaItems");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Contacts");
        }
    }
}
