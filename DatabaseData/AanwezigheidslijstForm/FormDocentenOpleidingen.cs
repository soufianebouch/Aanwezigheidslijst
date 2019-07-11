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
    public partial class FormDocentenOpleidingen : Form
    {
        public FormDocentenOpleidingen()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1 != null && comboBox2 != null)
            {
                using (var context = new AanwezigheidslijstContext())
                {
                    var deelnemersOpl = new DeelnemersOpleidingen();


                    var checkbox = comboBox1.SelectedItem as Opleidingsinformatie;
                    var nietOplDag = context.Opleidingsinformatie.SingleOrDefault(a => a.Opleiding == checkbox.Opleiding);
                    deelnemersOpl.Opleidingsinformatie = nietOplDag;

                    var checkbox2 = comboBox2.SelectedItem as Deelnemers;
                    var deelOpl = context.Deelnemers.SingleOrDefault(a => a.Id == checkbox2.Id);
                    deelnemersOpl.Deelnemers = deelOpl;

                    context.DeelnemersOpleidingen.Add(deelnemersOpl);
                    context.SaveChanges();
                    MessageBox.Show("deelnemer aan opleiding toegevoegd");
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
