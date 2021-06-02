namespace INFRAESTRUCTURE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Codigo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Codigo", c => c.String(nullable: false));
        }
    }
}
