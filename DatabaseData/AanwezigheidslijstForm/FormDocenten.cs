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
    public partial class FormDocenten : Form
    {
        public FormDocenten()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) //TOEVOEGEN
        {
            if (textBoxOpleiding.Text != "" && textBoxContactpersoon.Text != "")
            {
                using (var context = new AanwezigheidslijstContext())
                {
                    var docent = new Docenten();
                    docent.Naam = textBoxContactpersoon.Text;
                    docent.Bedrijf = textBoxOpleiding.Text;
                    context.Docenten.Add(docent);
                    context.SaveChanges();
                    MessageBox.Show("Docent toegevoegd");
                }
                listBox1.Items.Clear();
                using (var ctx = new AanwezigheidslijstContext())
                {
                    foreach (var item in ctx.Docenten)
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

        private void FormDocenten_Load(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                foreach (var item in context.Docenten)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e) //DELETE
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var b = listBox1.SelectedItem as Docenten;
                Docenten docent = context.Docenten.FirstOrDefault(a => a.Naam == b.Naam);
                context.Docenten.Remove(docent);

                DocentenOpleidingen opl = context.DocentenOpleidingen.FirstOrDefault(a => a.Docenten.Id == docent.Id);
                if (opl != null)
                {
                    context.DocentenOpleidingen.Remove(opl);
                }
                context.SaveChanges();
                MessageBox.Show("Docent verwijdert");

            }
            listBox1.Items.Clear();
            using (var ctx = new AanwezigheidslijstContext())
            {
                foreach (var item in ctx.Docenten)
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
                    var b = listBox1.SelectedItem as Docenten;
                    Docenten docent = context.Docenten.FirstOrDefault(a => a.Id == b.Id);
                    docent.Naam = textBoxContactpersoon.Text;
                    docent.Bedrijf = textBoxOpleiding.Text;
                    context.SaveChanges();
                    MessageBox.Show("Docent Aangepast");

                }

                listBox1.Items.Clear();
                using (var ctx = new AanwezigheidslijstContext())
                {
                    foreach (var item in ctx.Docenten)
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
        }


    }
}
