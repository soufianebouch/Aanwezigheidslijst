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

        private void TextBoxOpleidingscode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

