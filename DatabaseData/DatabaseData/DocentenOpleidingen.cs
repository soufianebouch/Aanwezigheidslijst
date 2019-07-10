using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAanmaken2
{
    public class DocentenOpleidingen
    {
        public int Id { get; set; }
        public virtual Docenten Docenten { get; set; }
        public virtual Opleidingsinformatie Opleidingsinformatie { get; set; }
    }
}
