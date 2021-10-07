namespace SoDe.Config
{
    class program
    {
        // length number
        // ex : two = {10 , 11 , ...} 
        public enum NUMBER_LENGTH
        {
            one = 1,
            two = 2,
            three = 3,
            four = 4,
            five = 5,
            six = 6,
        }


        public enum CHILD
        {
            G8 = 1,
            G7 = 1,
            G6 = 3,
            G5 = 1,
            G4 = 7,
            G3 = 2,
            G2 = 1,
            G1 = 1,
            GDB = 1,
        }

        public enum ORDER
        {
            G8,
            G7,
            G6,
            G5,
            G4,
            G3,
            G2,
            G1,
            GDB,
        }

        // time count back , tinh = giây
        public readonly static int TIME = 20;

        // delay
        public readonly static int delay = 200;

        // with height for g
        public static int widthForG = 100;
        public static int HeightForG = 590 / 18 + 1;

        // width heigth for score
        public static int widthForSc = 274;
        public static int HeightForSc = 590 / 18 + 1;
    }
}
