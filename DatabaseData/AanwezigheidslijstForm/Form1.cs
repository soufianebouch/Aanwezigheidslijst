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
    public partial class Beheer : Form
    {
        public Beheer()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var create = new CreateForm();
            create.Show();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var create = new FormBadgen();
            create.Show();
        }
    }
}
