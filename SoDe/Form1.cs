using model.Kqxs;
using SoDe.database;
using SoDe.helper;
using SoDe.systemxs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SoDe
{
    public partial class Form1 : Form
    {

        private Kqxs kqxs;
        private Systemxs systemxs;
        private readonly Rows rows;
        private Cols cols;
        private readonly List<Cols> listCols;
        private readonly List<Form> listForm;
        private readonly List<Kqxs> listKqxs;
        private readonly List<string> listWatting;

        public Form1()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            flowshow.Size = new Size(Width, Height);
            kqxs = new Kqxs();
            kqxs.make();
            rows = new Rows(kqxs);
            panelShow.Controls.Add(rows.build());

            listKqxs = new List<Kqxs>();
            listForm = new List<Form>();
            listCols = new List<Cols>();
            listWatting = new List<string>();
            ConnectDb.connect();
        }

        private void setup()
        {
            // kqxs , systemxs,table
            kqxs = new Kqxs();
            kqxs.make();
            cols = new Cols(kqxs, cbLocal.Text);
            systemxs = new Systemxs(kqxs, cols);
            flowshow.Controls.Add(cols.build());
            listCols.Add(cols);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
   
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string local = cbLocal.Text;

            if (listWatting.Contains(date + " " + local))
                return;

            if (ConnectDb.getContent(date, cbLocal.Text).Count > 0)
                return;

            listWatting.Add(date + " " + local);

            setup();
            
            systemxs.runer();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {

            foreach (Cols col in listCols)
            {
                col.turnoffThreadAnimation();
            }

        }

        private void dateTimePicker_Click(object sender, EventArgs e)
        {

            DateTimePicker date = sender as DateTimePicker;
            string dateCurent = date.Value.Date.ToString("dd/MM/yyyy");
            if (Helper.find(listForm, dateCurent + " " + cbLocal.Text) != -1)
                return;
            Kqxs kqxs = new Kqxs();
            Form form = Helper.show(dateCurent, cbLocal.Text, ref kqxs);
            if (form != null)
            {
                form.FormClosing += (object a, FormClosingEventArgs b) =>
                {
                    listKqxs.Remove(kqxs);
                    listForm.Remove(form);
                };
                listForm.Add(form);
                listKqxs.Add(kqxs);
            }
        }

        private void buttonWantNumber_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker.Text;
            string local = cbLocal.Text;
            string info = date + " " + local;
            int idx = Helper.find(listForm, info);
            if (idx != -1)
            {
                listForm[idx].TopMost = true;
                Kqxs kqxs = listKqxs[idx];
                Helper.findScore(kqxs, textBoxNumber.Text, info);
            }
            else
            {
                MessageBox.Show("việc này chỉ thực hiện khi obj form show!");
            }
        }
    }
}
