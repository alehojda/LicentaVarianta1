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
        private Boolean _favorit;
        public Boolean favorit
        {
            get { return _favorit; }
            set { _favorit = value; if (value) this.starIcon = "full.png"; else this.starIcon = "empty.png"; }
        }
        public string starIcon { get; set; }

        public RegiuneMontana()
        {
            if(this.favorit)
            {
                this.starIcon = "full.png";
            }
            else
            {
                this.starIcon = "empty.png";
            }
            Comentarii = new List<Comentariu>();
        }

    }
}