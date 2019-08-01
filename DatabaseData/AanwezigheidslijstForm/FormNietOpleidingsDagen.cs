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
    public partial class FormNietOpleidingsDagen : Form
    {
        public FormNietOpleidingsDagen()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ( dateTimePicker2.Value > DateTime.Now && checkBox1.Checked == true || checkBox2.Checked == true)
            {
                listBox1.Items.Clear();

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

                    var b = comboBox1.SelectedItem as Opleidingsinformatie;
                    //var deelnemers = context.Deelnemers.Select(deelnem => new { })
                    var query = from nto in context.NietOpleidingsDagen
                                join opli in context.Opleidingsinformatie on nto.Opleidingsinformatie.Id equals opli.Id
                                where nto.Opleidingsinformatie.Id == b.Id
                                select nto;
                    foreach (var item in query.Include(x => x.Opleidingsinformatie))
                    {
                        listBox1.Items.Add(item);
                    }
                    //foreach (var item in context.NietOpleidingsDagen.Include(x=>x.Opleidingsinformatie))
                    //{
                    //    listBox1.Items.Add(item);
                    //}
                }
                //using (var ctx = new AanwezigheidslijstContext())
                //{
                    
                //}
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
                    comboBox1.Items.Add(item);
                }
                var nietOpl = context.NietOpleidingsDagen.ToList();
                foreach (var item in nietOpl)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e) //VERWIJDEREN
        {
            if (listBox1.SelectedItem != null)
            {

                using (var context = new AanwezigheidslijstContext())
                {
                    var b = listBox1.SelectedItem as NietOpleidingsDagen;
                    NietOpleidingsDagen nietOpl = context.NietOpleidingsDagen.FirstOrDefault(a => a.Id == b.Id);
                    context.NietOpleidingsDagen.Remove(nietOpl);
                    MessageBox.Show("Vakantiedag verwijdert");
                    context.SaveChanges();

                    listBox1.Items.Clear();
                    var c = comboBox1.SelectedItem as Opleidingsinformatie;
                    //var deelnemers = context.Deelnemers.Select(deelnem => new { })
                    var query = from nto in context.NietOpleidingsDagen
                                join opli in context.Opleidingsinformatie on nto.Opleidingsinformatie.Id equals opli.Id
                                where nto.Opleidingsinformatie.Id == c.Id
                                select nto;
                    foreach (var item in query.Include(x => x.Opleidingsinformatie))
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
            //listBox1.Items.Clear();
            //using (var ctx = new AanwezigheidslijstContext())
            //{
            //    foreach (var item in ctx.NietOpleidingsDagen.Include(x => x.Opleidingsinformatie))
            //    {
            //        listBox1.Items.Add(item);
            //    }
            //}
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var context = new AanwezigheidslijstContext())
            {
                var b = comboBox1.SelectedItem as Opleidingsinformatie;
                //var deelnemers = context.Deelnemers.Select(deelnem => new { })
                var query = from nto in context.NietOpleidingsDagen
                            join opli in context.Opleidingsinformatie on nto.Opleidingsinformatie.Id equals opli.Id
                            where nto.Opleidingsinformatie.Id == b.Id
                            select nto;
                foreach (var item in query.Include(x => x.Opleidingsinformatie))
                {
                    listBox1.Items.Add(item);
                }
            }
        }
    }
}
