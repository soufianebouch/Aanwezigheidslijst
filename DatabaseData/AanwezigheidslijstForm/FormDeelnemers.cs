using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseAanmaken2;

namespace AanwezigheidslijstForm
{
    public partial class FormDeelnemers : Form
    {
        public FormDeelnemers()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            
            if (textBoxOpleiding.Text != "" && textBoxContactpersoon.Text != "" && dateTimePicker2.Value < DateTime.Now)
            {
                using (var context = new AanwezigheidslijstContext())
                {
                    var deelnemers = new Deelnemers();
                    deelnemers.Naam = textBoxContactpersoon.Text;
                    deelnemers.Geboortedatum = dateTimePicker2.Value;
                    deelnemers.Woonplaats = textBoxOpleiding.Text;
                    //NOG AF TE WERKEN

                    deelnemers.BadgeNummer = 0; 
                    context.Deelnemers.Add(deelnemers);
                    context.SaveChanges();
                    MessageBox.Show("deelnemer toegevoegd");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Gelieve de gegevens correct in te vullen");
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
