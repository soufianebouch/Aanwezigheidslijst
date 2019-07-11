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
                    var docentOpl = new DocentenOpleidingen();

                    var checkbox = comboBox1.SelectedItem as Opleidingsinformatie;
                    var nietOplDag = context.Opleidingsinformatie.SingleOrDefault(a => a.Opleiding == checkbox.Opleiding);
                    docentOpl.Opleidingsinformatie = nietOplDag;

                    var checkbox2 = comboBox2.SelectedItem as Docenten;
                    var deelOpl = context.Docenten.SingleOrDefault(a => a.Id == checkbox2.Id);
                    docentOpl.Docenten = deelOpl;

                    context.DocentenOpleidingen.Add(docentOpl);
                    context.SaveChanges();
                    MessageBox.Show("Docent aan opleiding toegevoegd");
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

        private void FormDocentenOpleidingen_Load(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var opleidingen = context.Opleidingsinformatie.ToList();
                foreach (var item in opleidingen)
                {
                    comboBox1.DisplayMember = nameof(Opleidingsinformatie.Opleiding);
                    comboBox1.Items.Add(item);
                }
                var docenten = context.Docenten.ToList();
                foreach (var item in docenten)
                {
                    comboBox2.DisplayMember = nameof(Docenten.Naam);
                    comboBox2.Items.Add(item);
                }
            }
        }
    }
}
