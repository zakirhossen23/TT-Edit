using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT_Edit.Classes
{
    public class SubtitleItemCustom
    {
        public string StartEndString
        {
            get;
            set;
        }
        public List<string> Lines
        {
            get;
            set;
        }

        public SubtitleItemCustom()
        {
            Lines = new List<string>();
        }

        public override string ToString()
        {
            return string.Format(format: "{0}: {1}", arg0: StartEndString, arg1: string.Join(Environment.NewLine, Lines));
        }
    }
}
