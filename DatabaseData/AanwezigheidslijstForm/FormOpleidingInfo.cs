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
    public partial class FormOpleidingInfo : Form
    {
        public FormOpleidingInfo()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBoxOpleiding.Text != "" && int.Parse(textBoxOpleidingscode.Text) != 0 && textBoxOpleidingInstelling.Text != "")
            {
                using (var context = new AanwezigheidslijstContext())
                {
                    var opleidingInfo = new Opleidingsinformatie();
                    opleidingInfo.Contactpersoon = textBoxContactpersoon.Text;
                    opleidingInfo.EindDatum = dateTimePicker2.Value;
                    opleidingInfo.Opleiding = textBoxOpleiding.Text;
                    opleidingInfo.Opleidingscode = int.Parse(textBoxOpleidingscode.Text);
                    opleidingInfo.Opleidingsinstelling = textBoxOpleidingInstelling.Text;
                    opleidingInfo.StartDatum = dateTimePicker1.Value;
                    context.Opleidingsinformatie.Add(opleidingInfo);
                    context.SaveChanges();
                    MessageBox.Show("Opleiding toegevoegd");
                }
            }
            else
            {
                MessageBox.Show("Gelieve de gegevens in te vullen");
            }

            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            var startDate = dateTimePicker1.Value;
            if (startDate < DateTime.Now)
            {
                MessageBox.Show("startdatum kan niet vroeger dan vandaag zijn");
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var b = listBox1.SelectedItem as Opleidingsinformatie;
                Opleidingsinformatie opl = context.Opleidingsinformatie.FirstOrDefault(a => a.Id == b.Id);
                opl.Contactpersoon = textBoxContactpersoon.Text;
                opl.EindDatum = dateTimePicker2.Value;
                opl.Opleiding = textBoxOpleiding.Text;
                opl.Opleidingscode = int.Parse(textBoxOpleidingscode.Text);
                opl.Opleidingsinstelling = textBoxOpleidingInstelling.Text;
                opl.StartDatum = dateTimePicker1.Value;
                context.SaveChanges();
                MessageBox.Show("opleiding aangepast");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var b = listBox1.SelectedItem as Opleidingsinformatie;
                Opleidingsinformatie opleiding = context.Opleidingsinformatie.FirstOrDefault(a => a.Opleiding == b.Opleiding);
                context.Opleidingsinformatie.Remove(opleiding);

                DeelnemersOpleidingen opl = context.DeelnemersOpleidingen.FirstOrDefault(a => a.Opleidingsinformatie.Id == opleiding.Id);
                if (opl != null)
                {
                    context.DeelnemersOpleidingen.Remove(opl);
                }

                Tijdsregistraties tijd = context.Tijdsregistraties.FirstOrDefault(a => a.Opleidingsinformatie.Id == opleiding.Id);
                if (tijd != null)
                {
                    context.Tijdsregistraties.Remove(tijd);
                }

                DocentenOpleidingen doc = context.DocentenOpleidingen.FirstOrDefault(a => a.Opleidingsinformatie.Id == opleiding.Id);
                if (doc != null)
                {
                    context.DocentenOpleidingen.Remove(doc);
                }

                NietOpleidingsDagen niet = context.NietOpleidingsDagen.FirstOrDefault(a => a.Opleidingsinformatie.Id == opleiding.Id);
                if (niet != null)
                {
                    context.NietOpleidingsDagen.Remove(niet);
                }

                context.SaveChanges();
                MessageBox.Show("Opleiding verwijdert");
            }
           
        }

        private void FormOpleidingInfo_Load(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                foreach (var item in context.Opleidingsinformatie)
                {
                    listBox1.Items.Add(item);
                }
            }
        }
    }
}

