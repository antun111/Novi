using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonskiImenik.Models
{
    public class Osoba
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Ime { get; set; }
        [StringLength(30)]
        public string Prezime { get; set; }
        [StringLength(30)]
        public string Adresa { get; set; }
        [StringLength(30)]
        public string Telefon { get; set; }
        public bool Aktivan { get; set; }

    }
}