using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilterLookUpsEditForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSingle_Click(object sender, EventArgs e)
        {
            FormSingleSource frm = new FormSingleSource();
            frm.Show();
        }

        private void btnDiff_Click(object sender, EventArgs e)
        {
            FormDifferentSources frm = new FormDifferentSources();
            frm.Show();
        }
    }
}
