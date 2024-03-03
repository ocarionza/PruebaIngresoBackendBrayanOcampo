using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Models;

[Table("transport")]
public partial class Transport
{
    [Key]
    [Column("transport_id")]
    public int TransportId { get; set; }

    [Column("fligth_carrier")]
    [StringLength(255)]
    [Unicode(false)]
    public string? FligthCarrier { get; set; }

    [Column("fligth_carrier_number")]
    [StringLength(255)]
    [Unicode(false)]
    public string? FligthCarrierNumber { get; set; }

    [InverseProperty("Transport")]
    public virtual ICollection<Fligth> Fligths { get; set; } = new List<Fligth>();
}
