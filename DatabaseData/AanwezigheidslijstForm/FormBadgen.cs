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
    public partial class FormBadgen : Form
    {
        public FormBadgen()
        {
            InitializeComponent();
        }

        private void FormBadgen_Load(object sender, EventArgs e)
        {
            using (var ctx = new AanwezigheidslijstContext())
            {
                var opl = ctx.Opleidingsinformatie.ToList();
                foreach (var item in opl)
                {
                    comboBox1.Items.Add(item);
                }
            }
            for (int i = 0; i < 50; i++)
            {
                listBox2.Items.Add("");
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using (var context = new AanwezigheidslijstContext())
            {
                var b = comboBox1.SelectedItem as Opleidingsinformatie;
                //var deelnemers = context.Deelnemers.Select(deelnem => new { })
                var query = from deel in context.Deelnemers
                            join deelopl in context.DeelnemersOpleidingen on deel.Id equals deelopl.Deelnemers.Id
                            where deelopl.Opleidingsinformatie.Id == b.Id
                            select deel;
                foreach (var item in query)
                {
                    listBox1.Items.Add(item);
                }
            }
            //using (var context = new AanwezigheidslijstContext())
            //{
            //    var b = comboBox1.SelectedItem as Opleidingsinformatie;
                
            //        listBox2.Items.Clear();
            //    var quer = (from tijd in context.Tijdsregistraties
            //                join deel in context.Deelnemers on tijd.Deelnemers.Id equals deel.Id
            //                where tijd.Opleidingsinformatie.Id == b.Id
            //                //orderby tijd.DateTime ascending
            //                select tijd.Deelnemers.Id).Distinct();
            //        foreach (var item in quer)
            //        {
            //            listBox2.Items.Add(item);
            //        }

            //    var list = listBox2.Items.Cast<Tijdsregistraties>().OrderBy(item => item.Deelnemers.Id).ToList();
            //    listBox2.Items.Clear();
            //    foreach (var item in list)
            //    {
            //        listBox2.Items.Add(item);
            //    }
            //}
        }

        private void Badge1_Click(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var tijd = new Tijdsregistraties();

                tijd.DateTime = DateTime.Now;

                var checkbox = comboBox1.SelectedItem as Opleidingsinformatie;
                var nietOplDag = context.Opleidingsinformatie.SingleOrDefault(a => a.Opleiding == checkbox.Opleiding);
                tijd.Opleidingsinformatie = nietOplDag;

                var checkbox2 = listBox1.SelectedItem as Deelnemers;
                var deelOpl = context.Deelnemers.SingleOrDefault(a => a.Id == checkbox2.Id);
                tijd.Deelnemers = deelOpl;

                context.Tijdsregistraties.Add(tijd);
                context.SaveChanges();
                MessageBox.Show("Gebadgt");
            }
            if (listBox2.Items[listBox1.SelectedIndex].ToString() == "")
            {
                listBox2.Items.Insert(listBox1.SelectedIndex, "IN gebadgt op: " + DateTime.Now);
            }
            else if (listBox2.Items[listBox1.SelectedIndex].ToString().Contains("IN"))
            {
                listBox2.Items.Insert(listBox1.SelectedIndex, "UIT gebadgt op: " + DateTime.Now);
            }
            else
            {
                listBox2.Items.Insert(listBox1.SelectedIndex, "IN gebadgt op: " + DateTime.Now);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var b = listBox1.SelectedItem as Deelnemers;

                listBox2.Items.Clear();
                var quer = from tijd in context.Tijdsregistraties
                            join deel in context.Deelnemers on tijd.Deelnemers.Id equals deel.Id
                            where tijd.Deelnemers.Id == b.Id
                            select tijd;

                var order = quer.OrderByDescending(x => x.DateTime);
                foreach (var item in order)
                {
                    listBox2.Items.Add(item);
                }
            }
        }
    }
}
