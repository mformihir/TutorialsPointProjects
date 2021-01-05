namespace EFCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        CurrCourse_CourseID = c.Int(),
                        PrevCourse_CourseID = c.Int(),
                        Student_StdntID = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Courses", t => t.CurrCourse_CourseID)
                .ForeignKey("dbo.Courses", t => t.PrevCourse_CourseID)
                .ForeignKey("dbo.Students", t => t.Student_StdntID)
                .Index(t => t.CurrCourse_CourseID)
                .Index(t => t.PrevCourse_CourseID)
                .Index(t => t.Student_StdntID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .Index(t => t.Credits);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "Student_StdntID", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "PrevCourse_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "CurrCourse_CourseID", "dbo.Courses");
            DropIndex("dbo.Courses", new[] { "Credits" });
            DropIndex("dbo.Enrollments", new[] { "Student_StdntID" });
            DropIndex("dbo.Enrollments", new[] { "PrevCourse_CourseID" });
            DropIndex("dbo.Enrollments", new[] { "CurrCourse_CourseID" });
            DropTable("dbo.Courses");
            DropTable("dbo.Enrollments");
        }
    }
}
