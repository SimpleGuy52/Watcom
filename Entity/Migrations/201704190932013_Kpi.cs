namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kpi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kpis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Value = c.Int(nullable: false),
                        PreviousValue = c.Int(nullable: false),
                        Measure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kpis");
        }
    }
}
