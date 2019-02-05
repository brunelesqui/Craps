using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Craps
{
    public partial class FormInputName : Form
    {
        private string nameRecord;

        public string NameRecord
        {
            get
            {
                return nameRecord;
            }
        }

        public FormInputName()
        {
            InitializeComponent();
            nameRecord = "no_name";
        }

        private void FormInputName_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            nameRecord = txtName.Text;
        }
    }
}
