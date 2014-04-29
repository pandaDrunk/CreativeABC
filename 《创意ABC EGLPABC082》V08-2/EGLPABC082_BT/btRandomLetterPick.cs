using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EGLPABC082_BT
{
    public class btRandomLetterPick
    {
        private Random RandomPick;
        private string[] AllLetters = new string[]{
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"};

        public void GetRandom()
        {
            DateTime aTime = new DateTime(1000);
            aTime = DateTime.Now;
            int nSeed = (int)(aTime.Millisecond);
            RandomPick = new Random(nSeed);
        }

        public string RandomLetter()
        {
            this.GetRandom();
            int index = (int)(this.RandomPick.NextDouble() * AllLetters.GetUpperBound(0));
            return AllLetters[index].ToString();
        }
    }
}
