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
    public partial class FormBadgen : Form
    {
        List<Tijdsregistraties> TijdLijst = new List<Tijdsregistraties>();
        List<Opleidingsinformatie> OplLijst = new List<Opleidingsinformatie>();
        List<DeelnemersOpleidingen> DeelnOplLijst = new List<DeelnemersOpleidingen>();
        List<Deelnemers> DeelnLijst = new List<Deelnemers>();
        public FormBadgen()
        {
            InitializeComponent();
        }

        private void FormBadgen_Load(object sender, EventArgs e)
        {
            using (var ctx = new AanwezigheidslijstContext())
            {
                DeelnLijst = ctx.Deelnemers.ToList();
                DeelnOplLijst = ctx.DeelnemersOpleidingen.ToList();
                TijdLijst = ctx.Tijdsregistraties.ToList();
                OplLijst = ctx.Opleidingsinformatie.ToList();
            }
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
            listBox2.Items.Clear();
            var controlsToRemove = new List<Control>();
            foreach (Control item in this.Controls)
            {
                if (item is Button || (item is Label && item.Name[0] == 't'))
                    controlsToRemove.Add(item);
            }

            foreach (Control item in controlsToRemove)
            {
                Controls.Remove(item);
            }
            listBox1.Items.Clear();
            
                var b = comboBox1.SelectedItem as Opleidingsinformatie;
                var query = from deel in DeelnLijst
                            join deelopl in DeelnOplLijst on deel.Id equals deelopl.Deelnemers.Id
                            where deelopl.Opleidingsinformatie.Id == b.Id
                            select deel;
                foreach (var item in query)
                {
                    listBox1.Items.Add(item);
                }


                int tellerX = 0;
                int tellerY = 0;
                foreach (Deelnemers item in query)
                {
                    Label label = new Label();
                    label.Location = new Point(22 + tellerX * 140, 235 + tellerY * 150);
                    label.Text = item.Naam;
                    label.Name = "t" + item.Naam + item.Id;

                    Button dynamicButton = new Button();
                    dynamicButton.Height = 90;
                    dynamicButton.Width = 110;
                    dynamicButton.Location = new Point(22 + tellerX * 140, 260 + tellerY * 150);
                    dynamicButton.Name = item.Naam;

                    tellerX++;
                    if (tellerX % 5 == 0)
                    {
                        tellerX = 0;
                        tellerY++;
                    }

                //var tijdPerDeeln = from t in TijdLijst
                //                   join opl in OplLijst on t.Opleidingsinformatie.Id equals opl.Id
                //                   where t.Deelnemers.Id == item.Id
                //                   select t;
                using (var context = new AanwezigheidslijstContext())
                {

                    var tijdPerDeeln = from t in context.Tijdsregistraties
                                       join opl in context.Opleidingsinformatie on t.Opleidingsinformatie.Id equals opl.Id
                                       where t.Deelnemers.Id == item.Id
                                       select t;
                if (tijdPerDeeln.Count() % 2 == 0)
                    {
                        dynamicButton.Text = "Badge In";
                    }
                    else
                    {
                        dynamicButton.Text = "Badge Out";
                    }

                    dynamicButton.Click += DynamicButton_Click;
                    Controls.Add(label);
                    Controls.Add(dynamicButton);
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
        private void DynamicButton_Click(object sender, EventArgs e)
        {
            using (var context = new AanwezigheidslijstContext())
            {
                var b = comboBox1.SelectedItem as Opleidingsinformatie;
                Button button = sender as Button;
                var deeln = from del in context.Deelnemers
                            join deelopl in context.DeelnemersOpleidingen on del.Id equals deelopl.Deelnemers.Id
                            where deelopl.Opleidingsinformatie.Id == b.Id
                            select del;

                Deelnemers deel = new Deelnemers();

                b = context.Opleidingsinformatie.SingleOrDefault(x => x.Id == b.Id);
                deel = context.Deelnemers.SingleOrDefault(d => d.Naam == button.Name);
                context.Tijdsregistraties.Add(new Tijdsregistraties { DateTime = DateTime.Now, Opleidingsinformatie = b, Deelnemers = deel });
                context.SaveChanges();
                TijdLijst = context.Tijdsregistraties.Include(x => x.Deelnemers).Include(x => x.Opleidingsinformatie).ToList();


                if (button.Text == "Badge In")
                {
                    button.Text = "Badge Out";
                }
                else
                {
                    button.Text = "Badge In";
                    var tijdPerDeel = from t in TijdLijst
                                      join opl in context.Opleidingsinformatie on t.Opleidingsinformatie.Id equals opl.Id
                                      where t.Deelnemers.Id == deel.Id
                                      select t;
                    TimeSpan tijdIn = tijdPerDeel.Last().DateTime - tijdPerDeel.Reverse().Skip(1).First().DateTime;
                    MessageBox.Show($"{deel.Naam} was {tijdIn} aanwezig.");
                }
            }
        }

        //private void Badge1_Click(object sender, EventArgs e)
        //{
        //    using (var context = new AanwezigheidslijstContext())
        //    {
        //        var tijd = new Tijdsregistraties();

        //        tijd.DateTime = DateTime.Now;

        //        var checkbox = comboBox1.SelectedItem as Opleidingsinformatie;
        //        var nietOplDag = context.Opleidingsinformatie.SingleOrDefault(a => a.Opleiding == checkbox.Opleiding);
        //        tijd.Opleidingsinformatie = nietOplDag;

        //        var checkbox2 = listBox1.SelectedItem as Deelnemers;
        //        var deelOpl = context.Deelnemers.SingleOrDefault(a => a.Id == checkbox2.Id);
        //        tijd.Deelnemers = deelOpl;

        //        context.Tijdsregistraties.Add(tijd);
        //        context.SaveChanges();
        //        MessageBox.Show("Gebadgt");
        //    }
        //    if (listBox2.Items[listBox1.SelectedIndex].ToString() == "")
        //    {
        //        listBox2.Items.Insert(listBox1.SelectedIndex, "IN gebadgt op: " + DateTime.Now);
        //    }
        //    else if (listBox2.Items[listBox1.SelectedIndex].ToString().Contains("IN"))
        //    {
        //        listBox2.Items.Insert(listBox1.SelectedIndex, "UIT gebadgt op: " + DateTime.Now);
        //    }
        //    else
        //    {
        //        listBox2.Items.Insert(listBox1.SelectedIndex, "IN gebadgt op: " + DateTime.Now);
        //    }
        //}

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
