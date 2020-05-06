using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace Licenta2.Models
{
    public class RegiuneMontana
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Locatie { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }
        [OneToMany]
        public List<Comentariu> Comentarii { get; set; }

        public RegiuneMontana()
        {
            Comentarii = new List<Comentariu>();
        }
    }
}