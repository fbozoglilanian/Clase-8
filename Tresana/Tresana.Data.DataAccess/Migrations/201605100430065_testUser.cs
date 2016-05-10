    namespace Tresana.Data.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Creator_Id", c => c.Int());
            CreateIndex("dbo.Tasks", "Creator_Id");
            AddForeignKey("dbo.Tasks", "Creator_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Creator_Id", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "Creator_Id" });
            DropColumn("dbo.Tasks", "Creator_Id");
        }
    }
}
