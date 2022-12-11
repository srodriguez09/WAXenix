namespace WATickets.Models.Cliente
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productos
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Codigo { get; set; }

        [StringLength(500)]
        public string Nombre { get; set; }

        public int idBodega { get; set; }

        public int idCategoria { get; set; }

        public int idProveedor { get; set; }


        [Column(TypeName = "money")]
        public decimal PrecioUnitario { get; set; }


        [Column(TypeName = "money")]
        public decimal Costo { get; set; }

        [Column(TypeName = "money")]
        public decimal Stock { get; set; }  

    }
}
