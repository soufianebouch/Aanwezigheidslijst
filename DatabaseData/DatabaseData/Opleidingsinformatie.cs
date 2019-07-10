using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAanmaken2
{
    public class Opleidingsinformatie
    {
        public int Id { get; set; }
        public string Opleidingsinstelling { get; set; }
        public string Opleiding { get; set; }
        public string Contactpersoon { get; set; }
        public int Opleidingscode { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
