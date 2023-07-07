using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RutasAPI.Data
{

    public partial class TblAutobuse
    {
        [Key]
        public int Id { get; set; }

        [StringLength(7)]
        [Unicode(false)]
        public string? Matricula { get; set; }

        [StringLength(20)]
        [Unicode(false)]
        public string? Modelo { get; set; }

        public byte? Capacidad { get; set; }

        public int? IdConductor { get; set; }

        public bool? EstaEliminado { get; set; }

        [ForeignKey("IdConductor")]
        [InverseProperty("TblAutobuses")]
        public virtual TblConductores? IdConductorNavigation { get; set; }

        [InverseProperty("IdAutobusNavigation")]
        public virtual ICollection<TblAutobusesRuta> TblAutobusesRuta { get; set; } = new List<TblAutobusesRuta>();
    }
}
