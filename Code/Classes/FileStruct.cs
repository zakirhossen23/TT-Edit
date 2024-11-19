using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT_Edit.Classes
{

    public class FileStruct
    {
        public FileStruct( string _filePath = "",string _fileName = "")
        {
            this.filePath = _filePath;
            this.fileName = _fileName;

        }
        public string fileName;
        public string filePath;
    }
}
