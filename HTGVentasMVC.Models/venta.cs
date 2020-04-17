namespace HTGVentasMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("venta")]
    public partial class venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public venta()
        {
            detalleVenta = new HashSet<detalleVenta>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal idVenta { get; set; }

        public float total { get; set; }

        [Column(TypeName = "numeric")]
        public decimal idCliente { get; set; }

        [Required]
        [StringLength(5)]
        public string idVendedor { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        [Column(TypeName = "money")]
        public decimal IVA { get; set; }

        public virtual cliente cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleVenta> detalleVenta { get; set; }

        public virtual vendedor vendedor { get; set; }
    }
}
