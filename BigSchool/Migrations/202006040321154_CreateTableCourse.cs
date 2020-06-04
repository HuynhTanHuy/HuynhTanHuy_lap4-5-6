namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Byte(nullable: false),
                        category_CategoryId = c.Byte(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.category_CategoryId)
                .Index(t => t.category_CategoryId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Place = c.String(nullable: false, maxLength: 255),
                        Datetime = c.DateTime(nullable: false),
                        Lecturer_Id = c.String(maxLength: 128),
                        LecturerId_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Lecturer_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LecturerId_Id, cascadeDelete: true)
                .Index(t => t.Lecturer_Id)
                .Index(t => t.LecturerId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LecturerId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "Lecturer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "LecturerId_Id" });
            DropIndex("dbo.Courses", new[] { "Lecturer_Id" });
            DropIndex("dbo.Categories", new[] { "category_CategoryId" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
