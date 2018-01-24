namespace MyVue.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Bills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatorUser = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        BillTypeId = c.Int(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Des = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillTypes", t => t.BillTypeId, cascadeDelete: true)
                .Index(t => t.BillTypeId);
            
            CreateTable(
                "dbo.BillTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FontStyle = c.String(),
                        ImgUrl = c.String(),
                        IsCountIn = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "BillTypeId", "dbo.BillTypes");
            DropIndex("dbo.Bills", new[] { "BillTypeId" });
            DropTable("dbo.BillTypes");
            DropTable("dbo.Bills");
        }
    }
}
