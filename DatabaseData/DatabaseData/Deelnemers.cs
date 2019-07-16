using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAanmaken2
{
    public class Deelnemers: IClass
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Woonplaats { get; set; }
        public int BadgeNummer { get; set; }
        public override string ToString()
        {
            return Naam + "  " + Woonplaats;
        }
    }
}
