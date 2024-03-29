﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Models;

[Table("journey_flight")]
public partial class JourneyFlight
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("journey_flight_id")]
    public int JourneyFlightId { get; set; }

    [Column("fligth_id")]
    public int FligthId { get; set; }

    [Column("journey_id")]
    public int JourneyId { get; set; }

    [ForeignKey("FligthId")]
    [InverseProperty("JourneyFlights")]
    public virtual Fligth Fligth { get; set; } = null!;

    [ForeignKey("JourneyId")]
    [InverseProperty("JourneyFlights")]
    public virtual Journey Journey { get; set; } = null!;
}
