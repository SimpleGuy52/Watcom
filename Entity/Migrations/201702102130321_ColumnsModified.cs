namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnsModified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Files", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Folders", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Folders", "Name", c => c.String());
            AlterColumn("dbo.Files", "Name", c => c.String());
        }
    }
}
