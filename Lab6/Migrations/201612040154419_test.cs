namespace Lab6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetID = c.Int(nullable: false, identity: true),
                        NickName = c.String(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PetID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        GalRanchConsumed = c.Single(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserPets",
                c => new
                    {
                        User_PersonID = c.Int(nullable: false),
                        Pet_PetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_PersonID, t.Pet_PetID })
                .ForeignKey("dbo.Users", t => t.User_PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.Pet_PetID, cascadeDelete: true)
                .Index(t => t.User_PersonID)
                .Index(t => t.Pet_PetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserPets", "Pet_PetID", "dbo.Pets");
            DropForeignKey("dbo.UserPets", "User_PersonID", "dbo.Users");
            DropIndex("dbo.UserPets", new[] { "Pet_PetID" });
            DropIndex("dbo.UserPets", new[] { "User_PersonID" });
            DropIndex("dbo.Users", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Pets", new[] { "ApplicationUser_Id" });
            DropTable("dbo.UserPets");
            DropTable("dbo.Users");
            DropTable("dbo.Pets");
        }
    }
}
