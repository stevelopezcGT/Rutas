using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RutasAPI.Data;

public partial class TblRuta
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Codigo { get; set; }

    [Column("Km_Recorridos", TypeName = "decimal(10, 4)")]
    public decimal? KmRecorridos { get; set; }

    public bool? EstaEliminado { get; set; }

    [InverseProperty("IdRutaNavigation")]
    public virtual ICollection<TblAutobusesRuta> TblAutobusesRuta { get; set; } = new List<TblAutobusesRuta>();

    [InverseProperty("IdRutaNavigation")]
    public virtual ICollection<TblRecorridosRuta> TblRecorridosRuta { get; set; } = new List<TblRecorridosRuta>();
}
