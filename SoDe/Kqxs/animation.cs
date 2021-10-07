using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SoDe.animation
{
    class Animation
    {
        public Label label;
        private bool runer = true;
        public Animation() { }
        public Animation(Label label)
        {
            this.label = label;
        }

        private void move(Bitmap file)
        {
            if (runer)
            {
                try
                {
                    if (label.InvokeRequired)
                        label.Invoke((Action)(() => label.Image = file));
                    else
                        label.Image = file;
                }
                catch (Exception e)
                {
                    stop();
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void run()
        {
            int cnt = 1;
            while (runer)
            {
                if (cnt == 1)
                    move(Properties.Resources.iconUp);
                else if (cnt == 2)
                    move(Properties.Resources.iconRight);
                else if (cnt == 3)
                    move(Properties.Resources.iconDown);
                else
                    move(Properties.Resources.iconLeft);
                cnt++;
                if (cnt > 4)
                    cnt %= 4;
                Thread.Sleep(130);
            }
            try
            {
                if (label != null)
                {
                    if (label.InvokeRequired)
                        label.Invoke((Action)(() => label.Image = null));
                    else
                        label.Image = null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("end animation");
        }

        public void stop()
        {
            runer = false;
        }

        public void start()
        {
            Thread thread = new Thread(new ThreadStart(run));
            thread.Start();
        }


    }
}
