using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_Plus
{
    public class TutorShift
    {
        public string initiatorName;
        public string acceptorName;/////
        public string start;
        public string end;
        public string date;
        public bool accepted;/////
        public bool givingshift;// false implies taking shift

        public TutorShift(string iName, string s, string e, string d, bool GorT)
        {
            initiatorName = iName;
            start = s;
            end = e;
            givingshift = GorT;
            date = d;
            accepted = false;

        }

    }
}
