﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BlueRoom.Models
{
    [Table("artist")]
    public partial class Artist
    {
        public Artist()
        {
            Shows = new HashSet<Show>();
            Songs = new HashSet<Song>();
        }

        [Key]
        [Column("artist_id")]
        public int ArtistId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }

        [InverseProperty(nameof(Show.PerformingArtist))]
        public virtual ICollection<Show> Shows { get; set; }
        [InverseProperty(nameof(Song.OriginalArtist))]
        public virtual ICollection<Song> Songs { get; set; }
    }
}