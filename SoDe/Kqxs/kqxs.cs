using SoDe.Config;
using System.Collections.Generic;
using System.Windows.Forms;


namespace model.Kqxs
{
    public class InforLabel
    {
        public Label label;
        public System.Drawing.Color color;
        public InforLabel() { }

        public InforLabel(Label label , System.Drawing.Color color) {
            this.label = label;
            this.color = color;
        }

    }

    public class Kqxs
    {

        public Dictionary<string, Label> mpxs;

        public Dictionary<int, int> mplength;

        public Dictionary<int, int> mpChill;

        public Dictionary<int, string> mpConvertG;

        public List<InforLabel> listLisght;

        public Label timeCount;

        public bool running;

        public Kqxs()
        {

        }

        public void make()
        {

            running = false;
            mpxs = new Dictionary<string, Label>();
            listLisght = new List<InforLabel>();

            mplength = new Dictionary<int, int>();
            mplength.Add((int)program.ORDER.G8, (int)program.NUMBER_LENGTH.two);
            mplength.Add((int)program.ORDER.G7, (int)program.NUMBER_LENGTH.three);
            mplength.Add((int)program.ORDER.G6, (int)program.NUMBER_LENGTH.four);
            mplength.Add((int)program.ORDER.G5, (int)program.NUMBER_LENGTH.four);
            mplength.Add((int)program.ORDER.G4, (int)program.NUMBER_LENGTH.five);
            mplength.Add((int)program.ORDER.G3, (int)program.NUMBER_LENGTH.five);
            mplength.Add((int)program.ORDER.G2, (int)program.NUMBER_LENGTH.five);
            mplength.Add((int)program.ORDER.G1, (int)program.NUMBER_LENGTH.five);
            mplength.Add((int)program.ORDER.GDB, (int)program.NUMBER_LENGTH.six);

            mpChill = new Dictionary<int, int>();
            mpChill.Add((int)program.ORDER.G8, (int)program.CHILD.G8);
            mpChill.Add((int)program.ORDER.G7, (int)program.CHILD.G7);
            mpChill.Add((int)program.ORDER.G6, (int)program.CHILD.G6);
            mpChill.Add((int)program.ORDER.G5, (int)program.CHILD.G5);
            mpChill.Add((int)program.ORDER.G4, (int)program.CHILD.G4);
            mpChill.Add((int)program.ORDER.G3, (int)program.CHILD.G3);
            mpChill.Add((int)program.ORDER.G2, (int)program.CHILD.G2);
            mpChill.Add((int)program.ORDER.G1, (int)program.CHILD.G1);
            mpChill.Add((int)program.ORDER.GDB, (int)program.CHILD.GDB);

            mpConvertG = new Dictionary<int, string>();
            mpConvertG.Add((int)program.ORDER.G8, "G8");
            mpConvertG.Add((int)program.ORDER.G7, "G7");
            mpConvertG.Add((int)program.ORDER.G6, "G6");
            mpConvertG.Add((int)program.ORDER.G5, "G5");
            mpConvertG.Add((int)program.ORDER.G4, "G4");
            mpConvertG.Add((int)program.ORDER.G3, "G3");
            mpConvertG.Add((int)program.ORDER.G2, "G2");
            mpConvertG.Add((int)program.ORDER.G1, "G1");
            mpConvertG.Add((int)program.ORDER.GDB, "GDB");

            timeCount = new Label();
        }

    }

}
