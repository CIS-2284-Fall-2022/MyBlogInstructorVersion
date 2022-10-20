using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Name
    {
        private string first;

        public string First
        {
            get { return first; }
            set { first = value; Calc(); }
        }

        private string last;

        public string Last
        {
            get { return last; }
            set { last = value; Calc(); }
        }

        private string middle;

        public string Middle
        {
            get { return middle; }
            set { middle = value; Calc(); }
        }

        public string Full { get; private set; }

        private void Calc()
        {
            if (middle != null)
            {
                Full = $"{first} {middle} {last}";
            }
            else
            {
                Full = $"{first} (NMI) {last}";
            }
        }
    }
}
