using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DescoperaMuntii.ViewModels;
using DescoperaMuntii.Models;
using DescoperaMuntii;

namespace DescoperaMuntii.Models
{
    public class RegiuniMontane
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [StringLength(500 , MinimumLength = 5)]
        [Display(Name = " Zona muntoasă ")]
        public string Regiune { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(400)]
        [Display(Name = "Vârf")]
        public string Varf { get; set; }

        public string Vreme { get; set; } //integrare vreme

        public string Comentarii { get; set; } //sectiune comentarii
         

    }
}
