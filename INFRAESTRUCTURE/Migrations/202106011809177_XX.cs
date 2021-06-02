namespace INFRAESTRUCTURE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class XX : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "FechaCreacion", c => c.String());
            AlterColumn("dbo.Students", "FechaModificacion", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "FechaModificacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "FechaCreacion", c => c.DateTime(nullable: false));
        }
    }
}
