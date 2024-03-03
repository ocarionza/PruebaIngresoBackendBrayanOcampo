using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaIngresoBackend.Repository.Models;

[Table("fligth")]
public partial class Fligth
{
    [Key]
    [Column("fligth_id")]
    public int FligthId { get; set; }

    [Column("transport_id")]
    public int TransportId { get; set; }

    [Column("origin")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Origin { get; set; }

    [Column("destination")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Destination { get; set; }

    [Column("price")]
    public double? Price { get; set; }

    [InverseProperty("Fligth")]
    public virtual ICollection<JourneyFlight> JourneyFlights { get; set; } = new List<JourneyFlight>();

    [ForeignKey("TransportId")]
    [InverseProperty("Fligths")]
    public virtual Transport Transport { get; set; } = null!;
}
