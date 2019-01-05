namespace Lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetCreatorNOTrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pets", "Creator", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "Creator", c => c.String(nullable: false));
        }
    }
}
