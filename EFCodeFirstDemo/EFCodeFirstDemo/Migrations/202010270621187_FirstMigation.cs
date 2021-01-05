namespace EFCodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrivingLicenses",
                c => new
                    {
                        LicenseNumber = c.Int(nullable: false),
                        IssuingCountry = c.String(nullable: false, maxLength: 128),
                        Issued = c.DateTime(nullable: false),
                        Expires = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.LicenseNumber, t.IssuingCountry });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DrivingLicenses");
        }
    }
}
