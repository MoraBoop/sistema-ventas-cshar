namespace HTGVentasMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("producto")]
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            detalleVenta = new HashSet<detalleVenta>();
        }

        [Key]
        [StringLength(5)]
        public string idProducto { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Column(TypeName = "money")]
        public decimal precioUnitario { get; set; }

        [Required]
        [StringLength(5)]
        public string idCategoria { get; set; }

        public virtual categoria categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleVenta> detalleVenta { get; set; }
    }
}
