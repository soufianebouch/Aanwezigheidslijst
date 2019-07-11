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
    public partial class FormNietOpleidingsDagen : Form
    {
        public FormNietOpleidingsDagen()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true || checkBox2.Checked == true && dateTimePicker2.Value > DateTime.Now)
            {
                using (var context = new AanwezigheidslijstContext())
                {
                    var nietopleidingsDagen = new NietOpleidingsDagen();
                    nietopleidingsDagen.Datum = dateTimePicker2.Value;
                    nietopleidingsDagen.Voormiddag = checkBox1.Checked;
                    nietopleidingsDagen.Namiddag = checkBox2.Checked;

                    var checkbox = comboBox1.SelectedItem as Opleidingsinformatie;
                    var nietOplDag = context.Opleidingsinformatie.SingleOrDefault(a => a.Opleiding == checkbox.Opleiding);

                    nietopleidingsDagen.Opleidingsinformatie = nietOplDag;


                    context.NietOpleidingsDagen.Add(nietopleidingsDagen);
                    context.SaveChanges();
                    MessageBox.Show("Niet opleidingsdag toegevoegd");
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

        private void FormNietOpleidingsDagen_Load(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var opleidingen = context.Opleidingsinformatie.ToList();
                foreach (var item in opleidingen)
                {
                    comboBox1.DisplayMember = nameof(Opleidingsinformatie.Opleiding);
                    comboBox1.Items.Add(item);
                }
                //var id = context.Opleidingsinformatie.Include
            }
        }
    }
}
