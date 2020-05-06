using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Licenta2.Models
{
    public class Comentariu
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(RegiuneMontana))]
        public int RegiuneMontanaId { get; set; }
        public string Continut { get; set; }
        public DateTime Data { get; set; }
    }
}
