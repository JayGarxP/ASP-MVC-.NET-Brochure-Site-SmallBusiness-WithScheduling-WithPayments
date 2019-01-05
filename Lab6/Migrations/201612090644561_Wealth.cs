namespace Lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wealth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wealths",
                c => new
                    {
                        WealthID = c.Int(nullable: false, identity: true),
                        Cash = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.WealthID);
            
            AddColumn("dbo.Users", "MyWealth_WealthID", c => c.Int());
            CreateIndex("dbo.Users", "MyWealth_WealthID");
            AddForeignKey("dbo.Users", "MyWealth_WealthID", "dbo.Wealths", "WealthID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "MyWealth_WealthID", "dbo.Wealths");
            DropIndex("dbo.Users", new[] { "MyWealth_WealthID" });
            DropColumn("dbo.Users", "MyWealth_WealthID");
            DropTable("dbo.Wealths");
        }
    }
}
