namespace WebApplicationExamen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionTablaServicio1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FacturaDetalles", "Cantidad", c => c.Int(nullable: false));
            DropColumn("dbo.FacturaDetalles", "Cacntidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FacturaDetalles", "Cacntidad", c => c.Int(nullable: false));
            DropColumn("dbo.FacturaDetalles", "Cantidad");
        }
    }
}
