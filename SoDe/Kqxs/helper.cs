using model.Kqxs;
using MongoDB.Bson;
using SoDe.Config;
using SoDe.database;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace SoDe.helper
{
    class Helper
    {
        private static readonly int[] number = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };


        public static string nextRandom(program.NUMBER_LENGTH nl)
        {
            string numberRandom = "";
            Random random = new Random();
            while (numberRandom.Length < (int)nl)
            {
                int idx = random.Next(number.Length);
                numberRandom += number[idx].ToString();

            }
            return numberRandom;
        }

        public static Form show(string date, string local, ref Kqxs kqxs)
        {
            List<BsonDocument> bsonData = ConnectDb.getContent(date, local);
            Form form = null;
            if (bsonData.Count == 0)
                MessageBox.Show(date + " " + local + " " + "not found!");
            else
            {
                BsonDocument bsonE = bsonData[0];
                form = new Form();
                form.AutoScroll = true;

                kqxs.make();

                Rows rows = new Rows(kqxs);
                TableLayoutPanel flowG = rows.build();
                form.Controls.Add(flowG);

                Cols cols = new Cols(kqxs, local, false);
                TableLayoutPanel flowC = cols.build();
                flowC.Location = new System.Drawing.Point(flowC.Location.X, flowC.Location.Y + 13);
                form.Controls.Add(flowC);

                cols.assgin(bsonE);

                form.Size = new System.Drawing.Size(flowG.Size.Width + program.widthForSc + 55, program.HeightForSc * 20 + 10);
                form.TopMost = true;
                form.Text = date;
                form.Name = date + " " + local;
                form.Show();
            }
            return form;
        }

        public static int find(List<Form> listForm, string found)
        {
            for (int i = 0; i < listForm.Count; i++)
            {
                if (listForm[i].Name == found)
                    return i;
            }
            return -1;
        }

        public static void findScore(Kqxs kqxs, string score, string info)
        {
            if (!kqxs.running)
            {
               

                new Thread(() =>
                {
                    try
                    {
                        score = score.Trim();
                        if (score.Length != 6)
                        {
                            MessageBox.Show(score + " không tìm thấy trong bảng hiện tại!" + " >> bảng " + info);
                            return;
                        }
                        kqxs.running = true;
                        foreach (InforLabel l in kqxs.listLisght)
                        {
                            l.label.BackColor = l.color;
                        }
                        kqxs.listLisght.Clear();
                        Array all = Enum.GetValues(typeof(program.ORDER));
                        
                        string messScore = "";

                        foreach (program.ORDER order in all)
                        {
                            int child = kqxs.mpChill[(int)order];
                            for (int i = 1; i <= child; i++)
                            {
                                string curent = order.ToString() + i.ToString();
                                System.Drawing.Color color = kqxs.mpxs[curent].BackColor;
                                kqxs.mpxs[curent].BackColor = System.Drawing.Color.BlueViolet;
                                Thread.Sleep(500);
                                int len = kqxs.mplength[(int)order];
                                if (kqxs.mpxs[curent].Text == score.Substring(score.Length - len , len))
                                {                        
                                    kqxs.mpxs[curent].BackColor = System.Drawing.Color.Green;
                                    kqxs.listLisght.Add(new InforLabel(kqxs.mpxs[curent] , color));
                                    messScore += kqxs.mpConvertG[(int)order] + ", ";                                                    
                                }
                                else
                                {
                                    kqxs.mpxs[curent].BackColor = color;
                                }
                            }
                        }

                        string text = kqxs.mpxs["GDB1"].Text;
                        if (text.EndsWith(score.Substring(1, 5)))
                        {
                            kqxs.mpxs["GDB1"].BackColor = System.Drawing.Color.Green;
                            kqxs.listLisght.Add(new InforLabel(kqxs.mpxs["GDB1"], System.Drawing.Color.White));
                            messScore += " Phụ Đặc Biệt , ";
                        }
                        else
                        {
                            bool ok = false;
                            for(int i = 0; i < text.Length; i++)
                            {
                                if (ok) break;
                                string bef = text.Substring(0, i);
                                string aft = text.Substring(Math.Min(i + 1, text.Length), text.Length - (i + 1));
                                string res = bef + aft;
                                for(int j = 0; j < score.Length; j++)
                                {
                                    string bef2 = score.Substring(0, j);
                                    string aft2 = score.Substring(Math.Min(j + 1, score.Length), score.Length - (j + 1));
                                    string res2 = bef2 + aft2;
                                    if(res == res2)
                                    {
                                        ok = true;
                                        break;
                                    }
                                }
                            }

                            if (ok) // found 124 in 1234 
                            {
                                kqxs.mpxs["GDB1"].BackColor = System.Drawing.Color.Green;
                                kqxs.listLisght.Add(new InforLabel(kqxs.mpxs["GDB1"], System.Drawing.Color.White));
                                messScore += " khuyến khích ";
                            }
                        }

                        if (messScore.Equals(""))
                            MessageBox.Show(score + " không tìm thấy trong bảng hiện tại!" + " >> bảng " + info);
                        else
                            MessageBox.Show("bạn đã trúng giải " + messScore.Trim() + " >> bảng " + info);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        kqxs.running = false;
                    }
                }).Start();
            }
        }
    }
}
