﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Models
{
    public partial class Artist
    {
        public Artist()
        {

        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Show> Shows { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}