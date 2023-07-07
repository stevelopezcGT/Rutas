using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RutasAPI.Data
{

    [Table("TblAutobuses_Ruta")]
    public partial class TblAutobusesRuta
    {
        [Key]
        public int Id { get; set; }

        public int? IdAutobus { get; set; }

        public int? IdRuta { get; set; }

        public bool? AutobusActivo { get; set; }

        public bool? EstaEliminado { get; set; }

        [ForeignKey("IdAutobus")]
        [InverseProperty("TblAutobusesRuta")]
        public virtual TblAutobuse? IdAutobusNavigation { get; set; }

        [ForeignKey("IdRuta")]
        [InverseProperty("TblAutobusesRuta")]
        public virtual TblRuta? IdRutaNavigation { get; set; }
    }
}
