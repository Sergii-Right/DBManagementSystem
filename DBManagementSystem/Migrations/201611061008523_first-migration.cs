namespace DBManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DBTables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DBasesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DBases", t => t.DBasesID, cascadeDelete: true)
                .Index(t => t.DBasesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DBTables", "DBasesID", "dbo.DBases");
            DropIndex("dbo.DBTables", new[] { "DBasesID" });
            DropTable("dbo.DBTables");
            DropTable("dbo.DBases");
        }
    }
}
