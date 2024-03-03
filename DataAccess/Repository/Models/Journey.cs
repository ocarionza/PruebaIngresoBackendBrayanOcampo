using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PruebaIngresoBackend.Repository.Models;

[Table("journey")]
public partial class Journey
{
    [Key]
    [Column("journey_id")]
    public int JourneyId { get; set; }

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

    [InverseProperty("Journey")]
    public virtual ICollection<JourneyFlight> JourneyFlights { get; set; } = new List<JourneyFlight>();
}
