namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KpiNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kpis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Measure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KpiValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        KpiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kpis", t => t.KpiId, cascadeDelete: true)
                .Index(t => t.KpiId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KpiValues", "KpiId", "dbo.Kpis");
            DropIndex("dbo.KpiValues", new[] { "KpiId" });
            DropTable("dbo.KpiValues");
            DropTable("dbo.Kpis");
        }
    }
}
