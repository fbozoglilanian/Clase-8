namespace Tresana.Data.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedRelation1 : DbMigration
    {
        public override void Up()
        {
            
            AlterColumn("dbo.Tasks", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Tasks", "FinishDate", c => c.DateTime());
            
        }

        public override void Down()
        {
            AlterColumn("dbo.Tasks", "FinishDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
