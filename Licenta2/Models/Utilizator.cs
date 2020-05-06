using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Licenta2.Models
{
    public class Utilizator
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        [Display (Name="Număr de telefon")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "Dimensiunea parolei trebuie să fie mai mare de 4 caractere!")]
        public string Password { get; set; }
       
    }
}
