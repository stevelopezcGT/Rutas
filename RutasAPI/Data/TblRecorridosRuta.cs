using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RutasAPI.Data
{

    public partial class TblRecorridosRuta
    {
        [Key]
        public int Id { get; set; }

        public int? IdRuta { get; set; }

        public int? IdCiudad { get; set; }

        public int? Orden { get; set; }

        public bool? EsInicio { get; set; }

        public bool? EsFinal { get; set; }

        public bool? EstaEliminado { get; set; }

        [ForeignKey("IdCiudad")]
        [InverseProperty("TblRecorridosRuta")]
        public virtual TblCiudades? IdCiudadNavigation { get; set; }

        [ForeignKey("IdRuta")]
        [InverseProperty("TblRecorridosRuta")]
        public virtual TblRuta? IdRutaNavigation { get; set; }
    }
}
