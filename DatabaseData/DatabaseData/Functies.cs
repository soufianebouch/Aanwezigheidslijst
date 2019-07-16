using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAanmaken2;
using System.Windows.Forms;


namespace DatabaseData
{
    class Functies
    {
        public void Verwijder(ref ListBox listbox)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var b = listbox.SelectedItem as DocentenOpleidingen;
                DocentenOpleidingen docentenOpleidingen = context.DocentenOpleidingen.FirstOrDefault(a => a.Opleidingsinformatie.Opleiding == b.Opleidingsinformatie.Opleiding);
                context.DocentenOpleidingen.Remove(docentenOpleidingen);
                MessageBox.Show("verwijderen succesvol");
                context.SaveChanges();
            }
        }

    }
}
