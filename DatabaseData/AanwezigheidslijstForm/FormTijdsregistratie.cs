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
    public partial class FormTijdsregistratie : Form
    {
        public FormTijdsregistratie()
        {
            InitializeComponent();
        }

        private void FormTijdsregistratie_Load(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var opleidingen = context.Opleidingsinformatie.ToList();
                foreach (var item in opleidingen)
                {
                    comboBox1.Items.Add(item);
                }
                var deelnemers = context.Deelnemers.ToList();
                foreach (var item in deelnemers)
                {
                    comboBox2.Items.Add(item);
                }
                var listbox = context.Tijdsregistraties.ToList();
                foreach (var item in listbox)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1 != null && comboBox2 != null)
            {
                using (var context = new AanwezigheidslijstContext())
                {
                    var tijd = new Tijdsregistraties();

                    tijd.DateTime = dateTimePicker1.Value;

                    var checkbox = comboBox1.SelectedItem as Opleidingsinformatie;
                    var nietOplDag = context.Opleidingsinformatie.SingleOrDefault(a => a.Opleiding == checkbox.Opleiding);
                    tijd.Opleidingsinformatie = nietOplDag;

                    var checkbox2 = comboBox2.SelectedItem as Deelnemers;
                    var deelOpl = context.Deelnemers.SingleOrDefault(a => a.Id == checkbox2.Id);
                    tijd.Deelnemers = deelOpl;

                    context.Tijdsregistraties.Add(tijd);
                    context.SaveChanges();
                    MessageBox.Show("Tijd geregistreerd");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Gelieve de gegevens correct in te vullen");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using (var ctx = new AanwezigheidslijstContext())
            {
                var b = listBox1.SelectedItem as Tijdsregistraties;
                Tijdsregistraties tijd = ctx.Tijdsregistraties.FirstOrDefault(a => a.Id == b.Id);
                ctx.Tijdsregistraties.Remove(tijd);
                MessageBox.Show("Tijdsregistratie verwijdert");
                ctx.SaveChanges();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
