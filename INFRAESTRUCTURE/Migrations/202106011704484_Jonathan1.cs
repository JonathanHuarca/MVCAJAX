namespace INFRAESTRUCTURE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jonathan1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "LastName", c => c.String());
            AddColumn("dbo.Students", "Codigo", c => c.String(nullable: false));
            AddColumn("dbo.Students", "FechaCreacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "FechaModificacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "FechaModificacion");
            DropColumn("dbo.Students", "FechaCreacion");
            DropColumn("dbo.Students", "Codigo");
            DropColumn("dbo.Students", "LastName");
        }
    }
}
