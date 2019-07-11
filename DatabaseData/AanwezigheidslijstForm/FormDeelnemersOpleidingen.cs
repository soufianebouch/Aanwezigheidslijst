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
    public partial class FormDeelnemersOpleidingen : Form
    {
        public FormDeelnemersOpleidingen()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1 != null && comboBox2 != null )
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

        private void FormDeelnemersOpleidingen_Load(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var opleidingen = context.Opleidingsinformatie.ToList();
                foreach (var item in opleidingen)
                {
                    comboBox1.DisplayMember = nameof(Opleidingsinformatie.Opleiding);
                    comboBox1.Items.Add(item);
                }
                var deelnemers = context.Deelnemers.ToList();
                foreach (var item in deelnemers)
                {
                    comboBox2.DisplayMember = nameof(Deelnemers.Naam);
                    comboBox2.Items.Add(item);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
