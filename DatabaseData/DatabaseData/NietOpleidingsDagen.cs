using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAanmaken2
{
    public class NietOpleidingsDagen
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public bool Voormiddag { get; set; }
        public bool Namiddag { get; set; }
        public virtual Opleidingsinformatie Opleidingsinformatie { get; set; }
        public override string ToString()
        {
            string dag;
            if (Voormiddag == true && Namiddag == true)
            {
                dag = "Volledige dag";
            }
            else if (Voormiddag == true && Namiddag == false)
            {
                dag = "Voormiddag";
            }
            else
            {
                dag = "Namiddag";
            }

            return Datum + "\t" + dag + "\t" + Opleidingsinformatie.Opleiding;
        }
    }
}
