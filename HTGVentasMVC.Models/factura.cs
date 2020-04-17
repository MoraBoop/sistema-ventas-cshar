namespace HTGVentasMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("factura")]
    public partial class factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public factura()
        {
            detalleVenta = new HashSet<detalleVenta>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal numFactura { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        public float IVA { get; set; }

        public float total { get; set; }

        public int numPago { get; set; }

        [Column(TypeName = "money")]
        public decimal? descuento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleVenta> detalleVenta { get; set; }

        public virtual modoPago modoPago { get; set; }
    }
}
