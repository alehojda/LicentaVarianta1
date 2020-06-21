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
       
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
    }
}
