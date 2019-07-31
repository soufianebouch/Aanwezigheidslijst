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
        private void Button1_Click(object sender, EventArgs e) //TOEVOEGEN
        {
            
            if (textBoxOpleiding.Text != "" && textBoxContactpersoon.Text != "" && dateTimePicker2.Value < DateTime.Now)
            {
                using (var context = new AanwezigheidslijstContext())
                {
                    var deelnemers = new Deelnemers();
                    deelnemers.Naam = textBoxContactpersoon.Text;
                    deelnemers.Geboortedatum = dateTimePicker2.Value;
                    deelnemers.Woonplaats = textBoxOpleiding.Text;
                   
                    context.Deelnemers.Add(deelnemers);
                    context.SaveChanges();
                    deelnemers.BadgeNummer = deelnemers.Id;
                    context.SaveChanges();

                    MessageBox.Show("deelnemer toegevoegd");
                }
                listBox1.Items.Clear();
                using (var context = new AanwezigheidslijstContext())
                {
                    foreach (var item in context.Deelnemers)
                    {
                        listBox1.Items.Add(item);
                    }
                }
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

        private void FormDeelnemers_Load(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                foreach (var item in context.Deelnemers)
                {
                    //listBox1.DisplayMember = nameof(Deelnemers.Naam);
                    listBox1.Items.Add(item);
                    //listBox1.Items.Add(item);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e) //REMOVE
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var b = listBox1.SelectedItem as Deelnemers;
                Deelnemers deelnemers = context.Deelnemers.FirstOrDefault(a => a.Id == b.Id);
                context.Deelnemers.Remove(deelnemers);

                DeelnemersOpleidingen opl = context.DeelnemersOpleidingen.FirstOrDefault(a => a.Deelnemers.Naam == deelnemers.Naam);
                if (opl != null)
                {
                    context.DeelnemersOpleidingen.Remove(opl);
                }

                var verwijdertijd = from tijdr in context.Tijdsregistraties
                                    join deeln in context.Deelnemers on tijdr.Deelnemers.Naam equals deeln.Naam
                                    where deeln.Naam == b.Naam
                                    select tijdr;
                foreach (var item in verwijdertijd)
                {
                    context.Tijdsregistraties.Remove(item);
                }


                //Tijdsregistraties tijd = context.Tijdsregistraties.FirstOrDefault(a => a.Deelnemers.Id == deelnemers.Id);
                //if (tijd != null)
                //{
                //    context.Tijdsregistraties.Remove(tijd);
                //}
                context.SaveChanges();
                MessageBox.Show("Deelnemer verwijdert");
            }
            listBox1.Items.Clear();
            using (var context = new AanwezigheidslijstContext())
            {
                foreach (var item in context.Deelnemers)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e) //AANPASSEN
        {
            if (listBox1.SelectedItem != null)
            {
                using (var context = new AanwezigheidslijstContext())
                {
                    var b = listBox1.SelectedItem as Deelnemers;
                    Deelnemers deelnemers = context.Deelnemers.FirstOrDefault(a => a.Id == b.Id);
                    deelnemers.Naam = textBoxContactpersoon.Text;
                    deelnemers.Geboortedatum = dateTimePicker2.Value;
                    deelnemers.Woonplaats = textBoxOpleiding.Text;
                    //NOG AF TE WERKEN
                    deelnemers.BadgeNummer = 0;
                    context.SaveChanges();
                    MessageBox.Show("Deelnemer aangepast");
                }
                listBox1.Items.Clear();
                using (var context = new AanwezigheidslijstContext())
                {
                    foreach (var item in context.Deelnemers)
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
        }
    }
}
