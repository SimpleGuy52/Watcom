namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileExtension : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "Extension", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "Extension");
        }
    }
}
