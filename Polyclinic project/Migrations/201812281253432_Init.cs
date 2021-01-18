namespace Polyclinic_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        City_code = c.Int(nullable: false, identity: true),
                        City_name = c.String(),
                    })
                .PrimaryKey(t => t.City_code);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Dep_num = c.Int(nullable: false, identity: true),
                        Pol_num = c.Int(nullable: false),
                        Dep_name = c.String(),
                    })
                .PrimaryKey(t => t.Dep_num)
                .ForeignKey("dbo.Polyclinics", t => t.Pol_num, cascadeDelete: true)
                .Index(t => t.Pol_num);
            
            CreateTable(
                "dbo.Polyclinics",
                c => new
                    {
                        Pol_num = c.Int(nullable: false, identity: true),
                        City_code = c.Int(nullable: false),
                        Pol_name = c.String(),
                    })
                .PrimaryKey(t => t.Pol_num)
                .ForeignKey("dbo.Cities", t => t.City_code, cascadeDelete: true)
                .Index(t => t.City_code);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Doc_id = c.Int(nullable: false, identity: true),
                        Dep_num = c.Int(nullable: false),
                        Doc_fnln = c.String(),
                        Doc_spec = c.String(),
                        Doc_office = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Doc_id)
                .ForeignKey("dbo.Departments", t => t.Dep_num, cascadeDelete: true)
                .Index(t => t.Dep_num);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Medcard_num = c.Int(nullable: false, identity: true),
                        Pat_fnln = c.String(),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        Phone = c.String(),
                        Insur_num = c.String(),
                        Passport = c.String(),
                    })
                .PrimaryKey(t => t.Medcard_num);
            
            CreateTable(
                "dbo.Receptions",
                c => new
                    {
                        App_time = c.String(nullable: false, maxLength: 128),
                        Doc_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.App_time)
                .ForeignKey("dbo.Doctors", t => t.Doc_id, cascadeDelete: true)
                .Index(t => t.Doc_id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Tick_num = c.Int(nullable: false, identity: true),
                        Doc_id = c.Int(nullable: false),
                        App_time = c.String(maxLength: 128),
                        pat_fnln = c.String(),
                        Medcard_num = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Tick_num)
                .ForeignKey("dbo.Doctors", t => t.Doc_id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Medcard_num, cascadeDelete: true)
                .ForeignKey("dbo.Receptions", t => t.App_time)
                .Index(t => t.Doc_id)
                .Index(t => t.App_time)
                .Index(t => t.Medcard_num);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "App_time", "dbo.Receptions");
            DropForeignKey("dbo.Tickets", "Medcard_num", "dbo.Patients");
            DropForeignKey("dbo.Tickets", "Doc_id", "dbo.Doctors");
            DropForeignKey("dbo.Receptions", "Doc_id", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "Dep_num", "dbo.Departments");
            DropForeignKey("dbo.Departments", "Pol_num", "dbo.Polyclinics");
            DropForeignKey("dbo.Polyclinics", "City_code", "dbo.Cities");
            DropIndex("dbo.Tickets", new[] { "Medcard_num" });
            DropIndex("dbo.Tickets", new[] { "App_time" });
            DropIndex("dbo.Tickets", new[] { "Doc_id" });
            DropIndex("dbo.Receptions", new[] { "Doc_id" });
            DropIndex("dbo.Doctors", new[] { "Dep_num" });
            DropIndex("dbo.Polyclinics", new[] { "City_code" });
            DropIndex("dbo.Departments", new[] { "Pol_num" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Receptions");
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
            DropTable("dbo.Polyclinics");
            DropTable("dbo.Departments");
            DropTable("dbo.Cities");
        }
    }
}
