namespace Lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatorINPetandUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "Creator", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "Creator");
        }
    }
}
