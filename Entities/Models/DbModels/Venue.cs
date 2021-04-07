﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Entities.Models
{
    [Table("venue")]
    public partial class Venue
    {
        [Key]
        [Column("venue_id")]
        public int VenueId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Required]
        [Column("city")]
        [StringLength(255)]
        public string City { get; set; }
        [Required]
        [Column("state")]
        [StringLength(55)]
        public string State { get; set; }
        [Required]
        [Column("country")]
        [StringLength(55)]
        public string Country { get; set; }
    }
}