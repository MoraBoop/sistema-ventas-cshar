namespace HTGVentasMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("modoPago")]
    public partial class modoPago
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public modoPago()
        {
            factura = new HashSet<factura>();
        }

        [Key]
        public int numPago { get; set; }

        [Required]
        [StringLength(25)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string otroDetalles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura> factura { get; set; }
    }
}
