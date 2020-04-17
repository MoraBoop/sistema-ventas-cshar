namespace HTGVentasMVC.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categoria",
                c => new
                    {
                        idCategoria = c.String(nullable: false, maxLength: 5),
                        nombre = c.String(nullable: false, maxLength: 50),
                        descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.idCategoria);
            
            CreateTable(
                "dbo.producto",
                c => new
                    {
                        idProducto = c.String(nullable: false, maxLength: 5),
                        nombre = c.String(nullable: false, maxLength: 50),
                        precioUnitario = c.Decimal(nullable: false, storeType: "money"),
                        idCategoria = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.idProducto)
                .ForeignKey("dbo.categoria", t => t.idCategoria)
                .Index(t => t.idCategoria);
            
            CreateTable(
                "dbo.detalleVenta",
                c => new
                    {
                        idDetalle = c.Int(nullable: false),
                        numFactura = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        idVenta = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        subTotal = c.Single(nullable: false),
                        idProducto = c.String(nullable: false, maxLength: 5),
                        descuento = c.Decimal(nullable: false, storeType: "money"),
                        cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idDetalle, t.numFactura })
                .ForeignKey("dbo.factura", t => t.numFactura)
                .ForeignKey("dbo.venta", t => t.idVenta)
                .ForeignKey("dbo.producto", t => t.idProducto)
                .Index(t => t.numFactura)
                .Index(t => t.idVenta)
                .Index(t => t.idProducto);
            
            CreateTable(
                "dbo.factura",
                c => new
                    {
                        numFactura = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        fecha = c.DateTime(nullable: false, storeType: "date"),
                        IVA = c.Single(nullable: false),
                        total = c.Single(nullable: false),
                        numPago = c.Int(nullable: false),
                        descuento = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.numFactura)
                .ForeignKey("dbo.modoPago", t => t.numPago)
                .Index(t => t.numPago);
            
            CreateTable(
                "dbo.modoPago",
                c => new
                    {
                        numPago = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 25),
                        otroDetalles = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.numPago);
            
            CreateTable(
                "dbo.venta",
                c => new
                    {
                        idVenta = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        total = c.Single(nullable: false),
                        idCliente = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        idVendedor = c.String(nullable: false, maxLength: 5),
                        fecha = c.DateTime(nullable: false, storeType: "date"),
                        IVA = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.idVenta)
                .ForeignKey("dbo.cliente", t => t.idCliente)
                .ForeignKey("dbo.vendedor", t => t.idVendedor)
                .Index(t => t.idCliente)
                .Index(t => t.idVendedor);
            
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        idCliente = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        nombre = c.String(nullable: false, maxLength: 30, unicode: false),
                        apPaterno = c.String(nullable: false, maxLength: 30, unicode: false),
                        apMaterno = c.String(nullable: false, maxLength: 30, unicode: false),
                        direccion = c.String(nullable: false, maxLength: 50, unicode: false),
                        telefono = c.String(nullable: false, maxLength: 30, unicode: false),
                        dni = c.Decimal(nullable: false, precision: 8, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.idCliente);
            
            CreateTable(
                "dbo.vendedor",
                c => new
                    {
                        idVendedor = c.String(nullable: false, maxLength: 5),
                        nombre = c.String(nullable: false, maxLength: 30),
                        apPaterno = c.String(nullable: false, maxLength: 30),
                        apMaterno = c.String(nullable: false, maxLength: 30),
                        dni = c.String(nullable: false, maxLength: 8),
                        telefono = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.idVendedor);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.producto", "idCategoria", "dbo.categoria");
            DropForeignKey("dbo.detalleVenta", "idProducto", "dbo.producto");
            DropForeignKey("dbo.venta", "idVendedor", "dbo.vendedor");
            DropForeignKey("dbo.detalleVenta", "idVenta", "dbo.venta");
            DropForeignKey("dbo.venta", "idCliente", "dbo.cliente");
            DropForeignKey("dbo.factura", "numPago", "dbo.modoPago");
            DropForeignKey("dbo.detalleVenta", "numFactura", "dbo.factura");
            DropIndex("dbo.venta", new[] { "idVendedor" });
            DropIndex("dbo.venta", new[] { "idCliente" });
            DropIndex("dbo.factura", new[] { "numPago" });
            DropIndex("dbo.detalleVenta", new[] { "idProducto" });
            DropIndex("dbo.detalleVenta", new[] { "idVenta" });
            DropIndex("dbo.detalleVenta", new[] { "numFactura" });
            DropIndex("dbo.producto", new[] { "idCategoria" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.vendedor");
            DropTable("dbo.cliente");
            DropTable("dbo.venta");
            DropTable("dbo.modoPago");
            DropTable("dbo.factura");
            DropTable("dbo.detalleVenta");
            DropTable("dbo.producto");
            DropTable("dbo.categoria");
        }
    }
}
