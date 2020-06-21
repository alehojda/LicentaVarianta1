using System;
using System.Collections.Generic;
using System.Text;
using Licenta2.Models;

namespace Licenta2.Models
{
    public static class RegiuniData
    {
         public static IList<RegiuneMontana> RegiuniDate { get; private set; }
        static RegiuniData() {

            RegiuniDate = new List<RegiuneMontana>();

            RegiuniDate.Add(new RegiuneMontana
        {
                Id = -1,
            Locatie = "684156",
            Nume = "Pietrosul Rodnei, Rodnei mountains",
            Descriere = "Pietrosul Rodnei is located between Maramures and Bistrita Nasaud county.",
            favorit = false,
            starIcon = "empty.png"

        });
            RegiuniDate.Add(new RegiuneMontana
            {
                Id = -2,
                Locatie = "686011",
                Nume = "Vf. Negoiu, Fagaras mountains",
                Descriere = " It has a maximum altitude of 2535 and it's located in Sibiu county.",
                favorit = false,
                starIcon = "empty.png"

            });

            RegiuniDate.Add(new RegiuneMontana
            {
                Id = -3,
                Locatie = "666759",
                Nume = "Vf. Moldoveanu, Fagaras mountains",
                Descriere = " It's the highest mountain of Romania with an altitude of 2544 m. It is located in Arges county. ",
                favorit = false,
                starIcon = "empty.png"

            });

            RegiuniDate.Add(new RegiuneMontana
            {
                Id = -4,
                Locatie = "683179",
                Nume = "Vf. Omu, Bucegi mountains",
                Descriere = " It has a maximum altitude of 2514 and it's located in Brasov county. ",
                favorit = false,
                starIcon = "empty.png"

            });

            RegiuniDate.Add(new RegiuneMontana
            {
                Id = -5,
                Locatie = "664745",
                Nume = "Vf. Pietrosul Calimanilor, Calimani mountains",
                Descriere = "Calimani mountains are the youngest moutains of Romania.",
                favorit = true,
                starIcon = "full.png"

            });
        }
        
    }
}
