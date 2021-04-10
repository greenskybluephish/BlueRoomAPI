﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Entities.Models
{
    [Table("song")]
    public partial class Song
    {
        public Song()
        {
        }

        [Key]
        [Column("song_id")]
        public int SongId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("original_artist_id")]
        public int OriginalArtistId { get; set; }

        [ForeignKey(nameof(OriginalArtistId))]
        [InverseProperty(nameof(Artist.Songs))]
        public virtual Artist OriginalArtist { get; set; }
        [InverseProperty(nameof(SongPerformance.Song))]
        public ICollection<SongPerformance> SongPerformances { get; set; }
    }
}