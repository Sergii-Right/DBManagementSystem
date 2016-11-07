namespace DBManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DBColumns", "DBTableID", c => c.Int(nullable: false));
            CreateIndex("dbo.DBColumns", "DBTableID");
            AddForeignKey("dbo.DBColumns", "DBTableID", "dbo.DBTables", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DBColumns", "DBTableID", "dbo.DBTables");
            DropIndex("dbo.DBColumns", new[] { "DBTableID" });
            DropColumn("dbo.DBColumns", "DBTableID");
        }
    }
}
