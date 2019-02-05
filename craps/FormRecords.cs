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
    public partial class FormRecords : Form
    {
        private List<Record> recordList;

        public List<Record> RecordList
        {
            set
            {
                recordList = value;
            }
        }

        public FormRecords()
        {
            InitializeComponent();
        }

        private void FormRecords_Load(object sender, EventArgs e)
        {
            lblName.Text = string.Empty;
            lblPoints.Text = string.Empty;

            if (recordList != null)
            {
                foreach (Record rec in recordList)
                {
                    lblPoints.Text += rec.point.ToString() + "\n";
                    lblName.Text += rec.name + "\n";
                }
            }
        }
    }
}
