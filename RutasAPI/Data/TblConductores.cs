using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RutasAPI.Data
{

    public partial class TblConductores
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string? Nombre { get; set; }

        public bool? EstaEliminado { get; set; }

        [InverseProperty("IdConductorNavigation")]
        public virtual ICollection<TblAutobuse> TblAutobuses { get; set; } = new List<TblAutobuse>();
    }
}
