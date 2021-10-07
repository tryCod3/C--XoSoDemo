using model.Kqxs;
using MongoDB.Bson;
using SoDe.animation;
using SoDe.Config;
using SoDe.database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace SoDe.helper
{
    class Rows
    {
        private TableLayoutPanel layoutPanel;
        private readonly Kqxs kqxs;

        public Rows() { setup(); }

        public Rows(Kqxs kqxs) { this.kqxs = kqxs; setup(); }

        private void setG()
        {
            Array allOrder = Enum.GetValues(typeof(program.ORDER));
            foreach (program.ORDER order in allOrder)
            {
                int child = kqxs.mpChill[(int)order];
                int w = program.widthForG - 30;
                int h = program.HeightForG * child;
                string text = kqxs.mpConvertG[(int)order];
                Label label = new Label()
                {
                    Width = w,
                    Height = h,
                    Text = text,
                    Name = text,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = ((int)order % 2 == 0 ? Color.White : Color.FromArgb(32, 32, 32)),
                    ForeColor = ((int)order % 2 == 0 ? Color.Black : Color.White)
                };
                listG.Add(label);
            }
        }

        public TableLayoutPanel build()
        {
            layoutPanel = new TableLayoutPanel();
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layoutPanel.Size = new Size(program.widthForG - 22, 590 + 8);
            layoutPanel.Location = new Point(3, 45);
            layoutPanel.BackColor = Color.White;
            layoutPanel.AutoScroll = true;
            layoutPanel.Padding = new Padding(3, 3, 3, 3);
            setG();
            foreach (Label c in listG)
            {
                layoutPanel.Controls.Add(c);
            }
            return layoutPanel;
        }

        public void setup()
        {
            listG = new List<Label>();
        }

        public List<Label> listG;

    }


    class Cols
    {

        private readonly Kqxs kqxs;
        private TableLayoutPanel layoutPanel;
        private List<Label> listSc;
        private readonly bool useAnimation;
        public List<Animation> listA;

        public string nameHeader;

        public Cols() { }

        public Cols(Kqxs kqxs, string nameHeader, bool useAnimation = true)
        {
            this.kqxs = kqxs;
            this.nameHeader = nameHeader;
            this.useAnimation = useAnimation;
        }

        public TableLayoutPanel build()
        {
            layoutPanel = new TableLayoutPanel();
            layoutPanel.Name = "layoutCols";
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            setup();
            layoutPanel.Height = program.HeightForSc * listSc.Count;
            layoutPanel.Width = program.widthForSc;
            layoutPanel.Location = new Point(program.widthForG, 0);
            listA = new List<Animation>();
            foreach (Label c in listSc)
            {
                layoutPanel.Controls.Add(c);
                if (useAnimation && c.Name != "local")
                {
                    Animation animation = new Animation(c);
                    listA.Add(animation);
                    animation.start();
                }
            }

            return layoutPanel;
        }

        public void turnoffThreadAnimation()
        {
            if (listA == null)
                return;
            foreach (Animation a in listA)
            {
                a.stop();
            }
        }

        private void setup()
        {
            listSc = new List<Label>();

            Array allC = Enum.GetValues(typeof(program.ORDER));
            int w = program.widthForSc;
            int h = program.HeightForSc;
            Label labelHeader = new Label()
            {
                Width = w,
                Height = h,
                Name = "local",
                Text = nameHeader,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };
            listSc.Add(labelHeader);
            kqxs.mpxs.Add(labelHeader.Name, labelHeader);
            foreach (program.ORDER order in allC)
            {
                int child = kqxs.mpChill[(int)order];
                for (int i = 1; i <= child; i++)
                {
                    Label label = new Label()
                    {
                        Width = w,
                        Height = h,
                        BackColor = ((int)order % 2 == 0 ? Color.White : Color.FromArgb(32, 32, 32)),
                        ForeColor = ((int)order % 2 == 0 ? Color.Black : Color.White),
                        Name = order.ToString() + i.ToString(),
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    kqxs.mpxs.Add(label.Name, label);
                    listSc.Add(label);
                }
            }
        
        }

        public void assgin(BsonDocument bsonE)
        {
            foreach (BsonElement bson in bsonE)
            {
                string name = bson.Name;
                string value = bson.Value.ToString();
                if (name == "_id" || name == "date")
                    continue;
                kqxs.mpxs[name].Text = value;
            }
        }

        public void save()
        {
            if (kqxs.mpxs == null || kqxs.mpChill == null || !ConnectDb.hasConnect())
                return;

            BsonDocument bsondata = new BsonDocument();

            Array all = Enum.GetValues(typeof(program.ORDER));

            bsondata.Add("date", DateTime.Now.ToString("dd/MM/yyyy"));

            bsondata.Add("local", nameHeader);

            foreach (program.ORDER order in all)
            {
                int child = kqxs.mpChill[(int)order];
                for (int i = 1; i <= child; i++)
                {
                    string curent = order.ToString() + i.ToString();
                    bsondata.Add(new BsonElement(curent, kqxs.mpxs[curent].Text));
                }
            }

            ConnectDb.insert<BsonDocument>(bsondata);
        }


    }

}
