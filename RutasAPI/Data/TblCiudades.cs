using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RutasAPI.Data
{

    public partial class TblCiudades
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string? Nombre { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string? Direccion { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string? Telefono { get; set; }

        public bool? EstaEliminado { get; set; }

        [InverseProperty("IdCiudadNavigation")]
        public virtual ICollection<TblRecorridosRuta> TblRecorridosRuta { get; set; } = new List<TblRecorridosRuta>();
    }
}
