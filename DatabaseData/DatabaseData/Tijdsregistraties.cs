using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DatabaseAanmaken2
{
    public class Tijdsregistraties
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Opleidingsinformatie Opleidingsinformatie { get; set; }
        public virtual Deelnemers Deelnemers { get; set; }
        public override string ToString()
        {
            return /*Deelnemers.Naam + " - " + Opleidingsinformatie.Opleiding + " - " +*/ DateTime.ToString()/*("MM/dd/yyyy H:mm") DateTime.ToLongTimeString() + "  " + DateTime.ToLongDateString()*/;
        }
    }
}
