namespace ASM2_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserClasses",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        ClassID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserID, t.ClassID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .Index(t => t.ClassID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserClasses", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.UserClasses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserClasses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserClasses", new[] { "ClassID" });
            DropTable("dbo.Classes");
            DropTable("dbo.UserClasses");
        }
    }
}
