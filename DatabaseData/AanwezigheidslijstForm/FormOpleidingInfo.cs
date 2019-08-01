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

        private void Button1_Click(object sender, EventArgs e) //OPLEIDING TOEVOEGEN
        {
            if (textBoxOpleiding.Text != "" && int.Parse(textBoxOpleidingscode.Text) != 0 && textBoxOpleidingInstelling.Text != ""
                && dateTimePicker1.Value.DayOfYear > DateTime.Now.DayOfYear && dateTimePicker2.Value.DayOfYear > dateTimePicker1.Value.DayOfYear)
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
                listBox1.Items.Clear();
                using (var context = new AanwezigheidslijstContext())
                {
                    foreach (var item in context.Opleidingsinformatie)
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

        

        private void Button4_Click(object sender, EventArgs e)   //EDIT
        {
            if (listBox1.SelectedItem != null)
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
                listBox1.Items.Clear();
                using (var context = new AanwezigheidslijstContext())
                {
                    foreach (var item in context.Opleidingsinformatie)
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)  //DELETE
        {
            if (listBox1.SelectedItem != null)
            {

            using (var context = new AanwezigheidslijstContext())
            {
                //OPLEIDING VERWIJDEREN
                var b = listBox1.SelectedItem as Opleidingsinformatie;
                Opleidingsinformatie opleiding = context.Opleidingsinformatie.FirstOrDefault(a => a.Opleiding == b.Opleiding);
                context.Opleidingsinformatie.Remove(opleiding);
                //*

                //DEELNEMEROPLEIDING VERWIJDEREN
                var opl = from deeln in context.DeelnemersOpleidingen
                          join opl1 in context.Opleidingsinformatie on deeln.Opleidingsinformatie.Opleiding equals opl1.Opleiding
                          where deeln.Opleidingsinformatie.Opleiding == b.Opleiding
                          select deeln;

                    foreach (var item in opl)
                    {
                        context.DeelnemersOpleidingen.Remove(item);
                    }
                //*

                //TIJDSREGISTRATIES VERWIJDEREN
                var verwijdertijd = from tijdr in context.Tijdsregistraties
                                    join opl1 in context.Opleidingsinformatie on tijdr.Opleidingsinformatie.Opleiding equals opl1.Opleiding
                                    where tijdr.Opleidingsinformatie.Opleiding == b.Opleiding
                                    select tijdr;

                foreach (var item in verwijdertijd)
                {
                    context.Tijdsregistraties.Remove(item);
                }
                //*

                //DOCENT VERWIJDEREN
                DocentenOpleidingen doc = context.DocentenOpleidingen.FirstOrDefault(a => a.Opleidingsinformatie.Id == opleiding.Id);
                if (doc != null)
                {
                    context.DocentenOpleidingen.Remove(doc);
                }
                //*

                //NIETOPLEIDINGSDAG VERWIJDEREN
                NietOpleidingsDagen niet = context.NietOpleidingsDagen.FirstOrDefault(a => a.Opleidingsinformatie.Id == opleiding.Id);
                if (niet != null)
                {
                    context.NietOpleidingsDagen.Remove(niet);
                }
                //*

                context.SaveChanges();
                MessageBox.Show("Opleiding verwijdert");
            }
            listBox1.Items.Clear();
            using (var context = new AanwezigheidslijstContext())
            {
                foreach (var item in context.Opleidingsinformatie)
                {
                    listBox1.Items.Add(item);
                }
            }

            }
        }

        

        private void TextBoxOpleidingscode_Validating(object sender, CancelEventArgs e)
        {
            int distance;
            if (int.TryParse(textBoxOpleidingscode.Text, out distance))
            {
            }
            else
            {
                MessageBox.Show("Code mag enkel nummerieke waarden bevatten");
                textBoxOpleidingscode.Clear();
            }
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
    }
}

