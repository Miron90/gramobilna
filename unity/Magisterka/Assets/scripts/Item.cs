using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.scripts
{
    class Item
    {
        public string typ;
        public double hpmulti;
        public double attmulti;
        public int lvl;

        public Item(string typ, double hpmulti, double attmulti, int lvl)
        {
            this.typ = typ;
            this.hpmulti = hpmulti;
            this.attmulti = attmulti;
            this.lvl = lvl;
        }
    }
}
