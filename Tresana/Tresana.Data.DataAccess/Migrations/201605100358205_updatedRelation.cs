namespace Tresana.Data.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "Creator_Id", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "Creator_Id" });
            DropIndex("dbo.Users", new[] { "Task_Id" });
            CreateTable(
                "dbo.TaskUsers",
                c => new
                    {
                        Task_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_Id, t.User_Id })
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Task_Id)
                .Index(t => t.User_Id);
            
            AlterColumn("dbo.Tasks", "Creator_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "Creator_Id");
            AddForeignKey("dbo.Tasks", "Creator_Id", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "Task_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Task_Id", c => c.Int());
            DropForeignKey("dbo.Tasks", "Creator_Id", "dbo.Users");
            DropForeignKey("dbo.TaskUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TaskUsers", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.TaskUsers", new[] { "User_Id" });
            DropIndex("dbo.TaskUsers", new[] { "Task_Id" });
            DropIndex("dbo.Tasks", new[] { "Creator_Id" });
            AlterColumn("dbo.Tasks", "Creator_Id", c => c.Int());
            DropTable("dbo.TaskUsers");
            CreateIndex("dbo.Users", "Task_Id");
            CreateIndex("dbo.Tasks", "Creator_Id");
            AddForeignKey("dbo.Tasks", "Creator_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Task_Id", "dbo.Tasks", "Id");
        }
    }
}
