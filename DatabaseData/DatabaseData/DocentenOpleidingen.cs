using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAanmaken2
{
    public class DocentenOpleidingen : IClass
    {
        public int Id { get; set; }
        public virtual Docenten Docenten { get; set; }
        public virtual Opleidingsinformatie Opleidingsinformatie { get; set; }
        public override string ToString()
        {
            return "Docent: "+ Docenten + "\t"+ "Opleidingsinformatie: "  + Opleidingsinformatie.Opleiding;
        }
    }
}
