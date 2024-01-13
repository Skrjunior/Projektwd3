using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProjektWD3.Models
{
    public class Anime_Filmy_a_Seriály
    {
        public int Id { get; set; }

        [Required]
        public string Nazov { get; set; }

        [DataType(DataType.Date)]
        public DateTime RokVydania { get; set; }

        [Required]
        public string Zaner { get; set; }

        public string Odkaz { get; set; }

        [Required]
        public string Typ { get; set; }

        public string? ObrazokCesta { get; set; } 

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile? ObrazokSoubor { get; set; } 
    }
}
