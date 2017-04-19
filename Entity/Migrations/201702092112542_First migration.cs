namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Firstmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Name", c => c.String());
        }
    }
}
