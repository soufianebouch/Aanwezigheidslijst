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

        private void Button1_Click(object sender, EventArgs e)
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

        private void FormDocenten_Load(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                foreach (var item in context.Docenten)
                {
                    listBox1.DisplayMember = nameof(Docenten.Naam);
                    listBox1.Items.Add(item);
                }
            }
        }
    }
}
