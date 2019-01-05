namespace Lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomUsers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserPets", newName: "PetUsers");
            DropPrimaryKey("dbo.PetUsers");
            AddColumn("dbo.Users", "creator", c => c.String(nullable: false));
            AddPrimaryKey("dbo.PetUsers", new[] { "Pet_PetID", "User_PersonID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PetUsers");
            DropColumn("dbo.Users", "creator");
            AddPrimaryKey("dbo.PetUsers", new[] { "User_PersonID", "Pet_PetID" });
            RenameTable(name: "dbo.PetUsers", newName: "UserPets");
        }
    }
}
