using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AanwezigheidslijstForm
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void OpleidingsInformatie_Click(object sender, EventArgs e)
        {
            var create = new FormOpleidingInfo();
            create.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var create = new FormDeelnemers();
            create.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var create = new FormNietOpleidingsDagen();
            create.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var create = new FormDeelnemersOpleidingen();
            create.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var create = new FormDocenten();
            create.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var create = new FormDocentenOpleidingen();
            create.Show();
        }
    }
}
