namespace WebApplicationExamen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizacionTablaFactura : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Nombre = c.String(nullable: false, maxLength: 25),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.FacturaDetalles",
                c => new
                    {
                        FacturaDetalleId = c.Int(nullable: false, identity: true),
                        FacturaId = c.Int(nullable: false),
                        ServicioId = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Int(nullable: false),
                        ISV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalLinea = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FacturaDetalleId)
                .ForeignKey("dbo.Facturas", t => t.FacturaId, cascadeDelete: true)
                .ForeignKey("dbo.Servicios", t => t.ServicioId, cascadeDelete: true)
                .Index(t => t.FacturaId)
                .Index(t => t.ServicioId);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalIVA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FacturaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        ServicioId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 5),
                        Descripcion = c.String(nullable: false, maxLength: 25),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ServicioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaDetalles", "ServicioId", "dbo.Servicios");
            DropForeignKey("dbo.FacturaDetalles", "FacturaId", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Facturas", new[] { "ClienteId" });
            DropIndex("dbo.FacturaDetalles", new[] { "ServicioId" });
            DropIndex("dbo.FacturaDetalles", new[] { "FacturaId" });
            DropTable("dbo.Servicios");
            DropTable("dbo.Facturas");
            DropTable("dbo.FacturaDetalles");
            DropTable("dbo.Clientes");
        }
    }
}
