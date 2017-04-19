namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilesAndFolders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FolderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Folders", t => t.FolderId, cascadeDelete: true)
                .Index(t => t.FolderId);
            
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Folders", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Folders", "ParentId", "dbo.Folders");
            DropForeignKey("dbo.Files", "FolderId", "dbo.Folders");
            DropIndex("dbo.Folders", new[] { "ParentId" });
            DropIndex("dbo.Files", new[] { "FolderId" });
            DropTable("dbo.Folders");
            DropTable("dbo.Files");
        }
    }
}
