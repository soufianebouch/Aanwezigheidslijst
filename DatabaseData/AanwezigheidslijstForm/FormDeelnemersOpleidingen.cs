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
using System.Data.Entity;

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
            if (comboBox1 != null && comboBox2 != null)
            {
                listBox1.Items.Clear();
                using (var context = new AanwezigheidslijstContext())
                {
                    var deelnemersOpl = new DeelnemersOpleidingen();


                    var checkbox = comboBox1.SelectedItem as Opleidingsinformatie;
                    var opl = context.Opleidingsinformatie.FirstOrDefault(a => a.Opleiding == checkbox.Opleiding);
                    deelnemersOpl.Opleidingsinformatie = opl;

                    var checkbox2 = comboBox2.SelectedItem as Deelnemers;
                    var deelOpl = context.Deelnemers.FirstOrDefault(a => a.Id == checkbox2.Id);
                    deelnemersOpl.Deelnemers = deelOpl;

                    context.DeelnemersOpleidingen.Add(deelnemersOpl);
                    context.SaveChanges();
                    MessageBox.Show("deelnemer aan opleiding toegevoegd");

                    var b = comboBox1.SelectedItem as Opleidingsinformatie;
                    var query = from dno in context.DeelnemersOpleidingen
                                join opli in context.Opleidingsinformatie on dno.Opleidingsinformatie.Id equals opli.Id
                                where dno.Opleidingsinformatie.Id == b.Id
                                select dno;
                    foreach (var item in query.Include(x => x.Opleidingsinformatie).Include(x => x.Deelnemers))
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

        private void FormDeelnemersOpleidingen_Load(object sender, EventArgs e)
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
                foreach (var item in context.DeelnemersOpleidingen)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e) //VERWIJDEREN
        {
            if (comboBox1.SelectedItem != null && listBox1.SelectedItem != null)
            {

                using (var context = new AanwezigheidslijstContext())
                {
                    var b = listBox1.SelectedItem as DeelnemersOpleidingen;


                    DeelnemersOpleidingen deelnemersOpl = context.DeelnemersOpleidingen.FirstOrDefault(a => a.Deelnemers.Naam == b.Deelnemers.Naam);
                    context.DeelnemersOpleidingen.Remove(deelnemersOpl);
                    MessageBox.Show("deelnemer is uitgeschreven");
                    context.SaveChanges();

                    listBox1.Items.Clear();
                    var c = comboBox1.SelectedItem as Opleidingsinformatie;
                    var query = from dno in context.DeelnemersOpleidingen
                                join opli in context.Opleidingsinformatie on dno.Opleidingsinformatie.Id equals opli.Id
                                where dno.Opleidingsinformatie.Id == c.Id
                                select dno;
                    foreach (var item in query.Include(x => x.Opleidingsinformatie).Include(x => x.Deelnemers))
                    {
                        listBox1.Items.Add(item);
                    }

                }
            }
            else
            {
                MessageBox.Show("selecteer item in listbox en combobox");
            }
        }

        private void Button4_Click(object sender, EventArgs e) //AANPASSEN
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var b = listBox1.SelectedItem as DeelnemersOpleidingen;
                DeelnemersOpleidingen deelnemersOpl = context.DeelnemersOpleidingen.FirstOrDefault(a => a.Deelnemers.Naam == b.Deelnemers.Naam);

                var checkbox2 = comboBox2.SelectedItem as Deelnemers;
                Deelnemers dln = context.Deelnemers.FirstOrDefault(a => a.Id == checkbox2.Id);
                deelnemersOpl.Deelnemers = dln;

                var checkbox = comboBox1.SelectedItem as Opleidingsinformatie;
                Opleidingsinformatie opl = context.Opleidingsinformatie.FirstOrDefault(a => a.Id == checkbox.Id);
                deelnemersOpl.Opleidingsinformatie = opl;
                context.SaveChanges();
                MessageBox.Show("Aangepast");

                listBox1.Items.Clear();

                var c = comboBox1.SelectedItem as Opleidingsinformatie;
                var query = from dno in context.DeelnemersOpleidingen
                            join opli in context.Opleidingsinformatie on dno.Opleidingsinformatie.Id equals opli.Id
                            where dno.Opleidingsinformatie.Id == c.Id
                            select dno;
                foreach (var item in query.Include(x => x.Opleidingsinformatie).Include(x => x.Deelnemers))
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) //INDEX VERANDEREN
        {
            listBox1.Items.Clear();
            using (var context = new AanwezigheidslijstContext())
            {
                var b = comboBox1.SelectedItem as Opleidingsinformatie;
                var query = from dno in context.DeelnemersOpleidingen
                            join opli in context.Opleidingsinformatie on dno.Opleidingsinformatie.Id equals opli.Id
                            where dno.Opleidingsinformatie.Id == b.Id
                            select dno;
                foreach (var item in query.Include(x => x.Opleidingsinformatie).Include(x => x.Deelnemers))
                {
                    listBox1.Items.Add(item);
                }
            }
        }
    }
}
