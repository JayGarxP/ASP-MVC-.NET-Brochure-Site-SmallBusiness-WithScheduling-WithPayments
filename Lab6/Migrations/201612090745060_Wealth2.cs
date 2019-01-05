namespace Lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wealth2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "Species", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "Species");
        }
    }
}
