using model.Kqxs;
using SoDe.animation;
using SoDe.Config;
using SoDe.database;
using SoDe.helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;


namespace SoDe.systemxs
{
    class Systemxs
    {

        private int time;
        private readonly string name;
        private readonly Kqxs kqxs;
        private readonly Cols cols;

        private readonly Dictionary<string, bool> have = new Dictionary<string, bool>();

        public Systemxs()
        {

        }

        public Systemxs(Kqxs kqxs, Cols cols)
        {
            this.kqxs = kqxs;
            this.cols = cols;
            name = kqxs.GetHashCode().ToString();
        }

        private void setDefault()
        {
            have.Clear();
            time = program.TIME;
        }

        private void showTimeCount(string time)
        {

            if (kqxs.timeCount.InvokeRequired)
            {
                kqxs.timeCount.Invoke((Action)(() =>
                            kqxs.timeCount.Text = time));
            }
            else
            {
                kqxs.timeCount.Text = time;
            }
        }

        private void showNumber(string curent, string number)
        {
            if (kqxs.mpxs[curent].InvokeRequired)
            {
                kqxs.mpxs[curent].Invoke((Action)(() => kqxs.mpxs[curent].Text = number));
            }
            else
            {
                kqxs.mpxs[curent].Text = number;
            }

        }

        private void turnOffImage(string curent)
        {
            foreach (Animation l in cols.listA)
            {
                if (l.label.Name == curent)
                {
                    l.stop();
                    cols.listA.Remove(l);
                    break;
                }
            }
        }

        private string fillter(string curentNumber)
        {
            int length = curentNumber.Length;
            while (have.ContainsKey(curentNumber))
            {
                curentNumber = Helper.nextRandom((program.NUMBER_LENGTH)length);
            }
            return curentNumber;
        }

        private void startxs()
        {
            int defautValue = 100;
            try
            {
                setDefault();
                Array all = Enum.GetValues(typeof(program.ORDER));
                foreach (program.ORDER order in all)
                {
              
                    int child = (int)kqxs.mpChill[(int)order];
                    for (int i = 1; i <= child; i++)
                    {
                        string curent = order.ToString() + i.ToString();
                        long sum = defautValue * time; // 1000s * time
                        turnOffImage(curent);
                        while (sum > 0)
                        {
                            if ((int)order % 2 == 1)
                                kqxs.mpxs[curent].ForeColor = Color.White;
                            string number = Helper.nextRandom((program.NUMBER_LENGTH)kqxs.mplength[(int)order]);
                            if (have.ContainsKey(number))
                                number = fillter(number);
                            showNumber(curent, number);
                            have.Add(number, true);
                            sum -= defautValue;
                            Thread.Sleep(program.delay);
                        }
                    }
                }
                // here save db
                lock (ConnectDb.getInstance())
                {
                    cols.save();
                }
            }
            catch (Exception e) // turn when thread is run
            {
                Console.WriteLine(e.Message);
            }
        }

        public void runer()
        {
            ThreadStart start = new ThreadStart(startxs);
            Thread thread = new Thread(start);
            thread.Start();
        }

    }
}
