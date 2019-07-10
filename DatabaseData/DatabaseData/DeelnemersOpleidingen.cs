using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAanmaken2
{
    public class DeelnemersOpleidingen
    {
        public int Id { get; set; }
        public virtual Deelnemers Deelnemers { get; set; }
        public virtual Opleidingsinformatie Opleidingsinformatie { get; set; }
    }
}
