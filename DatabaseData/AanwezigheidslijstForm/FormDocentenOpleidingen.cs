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
    public partial class FormDocentenOpleidingen : Form
    {
        public FormDocentenOpleidingen()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) //TOEVOEGEN
        {
            listBox1.Items.Clear();

            if (comboBox1 != null && comboBox2 != null)
            {
                using (var context = new AanwezigheidslijstContext())
                {
                    var docentOpl = new DocentenOpleidingen();

                    var checkbox = comboBox2.SelectedItem as Docenten;
                    var docent = context.Docenten.SingleOrDefault(a => a.Id == checkbox.Id);
                    docentOpl.Docenten = docent;

                    //docentOpl.Docenten = comboBox2.SelectedItem as Docenten;

                    var checkbox2 = comboBox1.SelectedItem as Opleidingsinformatie;
                    var opl = context.Opleidingsinformatie.SingleOrDefault(a => a.Id == checkbox2.Id);
                    docentOpl.Opleidingsinformatie = opl;

                    context.DocentenOpleidingen.Add(docentOpl);
                    context.SaveChanges();
                    MessageBox.Show("Docent aan opleiding toegevoegd");

                    var b = comboBox1.SelectedItem as Opleidingsinformatie;
                    var query = from dco in context.DocentenOpleidingen
                                join opli in context.Opleidingsinformatie on dco.Opleidingsinformatie.Id equals opli.Id
                                where dco.Opleidingsinformatie.Id == b.Id
                                select dco;
                    foreach (var item in query.Include(x => x.Opleidingsinformatie).Include(x=>x.Docenten))
                    {
                        listBox1.Items.Add(item);
                    }
                }
                //using (var ctx = new AanwezigheidslijstContext())
                //{
                //    foreach (var item in ctx.DocentenOpleidingen)
                //    {
                //        listBox1.Items.Add(item);
                //    }
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

        private void FormDocentenOpleidingen_Load(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var opleidingen = context.Opleidingsinformatie.ToList();
                foreach (var item in opleidingen)
                {
                    comboBox1.Items.Add(item);
                }
                var docenten = context.Docenten.ToList();
                foreach (var item in docenten)
                {
                    comboBox2.Items.Add(item);
                }
                foreach (var item in context.DocentenOpleidingen)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e) //VERWIJDEREN
        {
            using (var context = new AanwezigheidslijstContext())
            {
                if (comboBox1.SelectedItem != null && listBox1.SelectedItem!= null)
                {
                    var b = listBox1.SelectedItem as DocentenOpleidingen;
                    DocentenOpleidingen docentenOpleidingen = context.DocentenOpleidingen.FirstOrDefault(a => a.Docenten.Id == b.Docenten.Id);
                    context.DocentenOpleidingen.Remove(docentenOpleidingen);
                    MessageBox.Show("docent is uitgeschreven");
                    context.SaveChanges();

                    listBox1.Items.Clear();

                    var c = comboBox1.SelectedItem as Opleidingsinformatie;
                    var query = from dco in context.DocentenOpleidingen
                                join opli in context.Opleidingsinformatie on dco.Opleidingsinformatie.Id equals opli.Id
                                where dco.Opleidingsinformatie.Id == c.Id
                                select dco;
                    foreach (var item in query.Include(x => x.Opleidingsinformatie).Include(x => x.Docenten))
                    {
                        listBox1.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Kies eerst de opleiding");
                }
                
            }
        }

        private void Button4_Click(object sender, EventArgs e) //AANPASSEN
        {
            if (comboBox1.SelectedItem != null && listBox1.SelectedItem != null)
            {
                using (var context = new AanwezigheidslijstContext())
                {
                    var b = listBox1.SelectedItem as DocentenOpleidingen;
                    DocentenOpleidingen deelnemersOpl = context.DocentenOpleidingen.FirstOrDefault(a => a.Docenten.Id == b.Docenten.Id);

                    var checkbox2 = comboBox2.SelectedItem as Docenten;
                    Docenten dln = context.Docenten.FirstOrDefault(a => a.Id == checkbox2.Id);
                    deelnemersOpl.Docenten = dln;

                    var checkbox = comboBox1.SelectedItem as Opleidingsinformatie;
                    Opleidingsinformatie opl = context.Opleidingsinformatie.FirstOrDefault(a => a.Id == checkbox.Id);
                    deelnemersOpl.Opleidingsinformatie = opl;
                    context.SaveChanges();
                    MessageBox.Show("Aangepast");

                    listBox1.Items.Clear();

                    var c = comboBox1.SelectedItem as Opleidingsinformatie;
                    var query = from dco in context.DocentenOpleidingen
                                join opli in context.Opleidingsinformatie on dco.Opleidingsinformatie.Id equals opli.Id
                                where dco.Opleidingsinformatie.Id == c.Id
                                select dco;
                    foreach (var item in query.Include(x => x.Opleidingsinformatie).Include(x => x.Docenten))
                    {
                        listBox1.Items.Add(item);
                    }
                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var context = new AanwezigheidslijstContext())
            {
                var c = comboBox1.SelectedItem as Opleidingsinformatie;
                var query = from dco in context.DocentenOpleidingen
                            join opli in context.Opleidingsinformatie on dco.Opleidingsinformatie.Id equals opli.Id
                            where dco.Opleidingsinformatie.Id == c.Id
                            select dco;
                foreach (var item in query.Include(x => x.Opleidingsinformatie).Include(x => x.Docenten))
                {
                    listBox1.Items.Add(item);
                }
            }
        }
    }
}
