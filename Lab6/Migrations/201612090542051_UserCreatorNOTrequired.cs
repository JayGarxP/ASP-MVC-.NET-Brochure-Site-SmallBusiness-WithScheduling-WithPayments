namespace Lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCreatorNOTrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "creator", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "creator", c => c.String(nullable: false));
        }
    }
}
