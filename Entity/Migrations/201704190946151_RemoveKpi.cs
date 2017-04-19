namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveKpi : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Kpis");
        }
        
        public override void Down()
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
    }
}
