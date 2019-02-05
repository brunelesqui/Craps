using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Craps
{
    public partial class FormMain : Form
    {
        private const int COUNT_RECORDS = 10;
        private const string FILE_NAME = "records.txt";

        private List<Record> records;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            records = new List<Record>();
            ReadFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCredits credits = new FormCredits();
            credits.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 play = new Form1();
            play.ShowDialog();
            decimal total = play.Total;
            SetRecord(total);
            SaveFile();
        }

        private void SetRecord(decimal argTotal)
        {
            for(int i=0; i < records.Count -1; i++)
            {
                if(argTotal > records[i].point)
                {
                    FormInputName inputName = new FormInputName();
                    inputName.ShowDialog();
                    string name = inputName.NameRecord;
                    records.Insert(i, new Record(name, argTotal));
                    break;
                }
            }

            records.RemoveAt(records.Count - 1);
        }

        private void ReadFile()
        {
            StreamReader reader = new StreamReader(FILE_NAME);

            string line = reader.ReadLine();
                        
            while (line != null)
            {
                records.Add(
                    new Record(UtilityRecord.GetName(line), UtilityRecord.GetPoint(line))
                    );

                line = reader.ReadLine();
            }

            reader.Close();
        }

        private void SaveFile()
        {
            StreamWriter writer = new StreamWriter(FILE_NAME);

            foreach(Record rec in records)
            {
                string line = rec.point.ToString() + ";" + rec.name;
                writer.WriteLine(line);
            }

            writer.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FormRecords records = new FormRecords();
            records.RecordList = this.records;
            records.ShowDialog();
        }
    }
}
