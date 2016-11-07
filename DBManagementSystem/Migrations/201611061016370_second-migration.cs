namespace DBManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBColumns",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DBRows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Content = c.String(),
                        DBRowID = c.Int(nullable: false),
                        DBColumn_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DBColumns", t => t.DBColumn_ID)
                .Index(t => t.DBColumn_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DBRows", "DBColumn_ID", "dbo.DBColumns");
            DropIndex("dbo.DBRows", new[] { "DBColumn_ID" });
            DropTable("dbo.DBRows");
            DropTable("dbo.DBColumns");
        }
    }
}
