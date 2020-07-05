using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xr_Sec.Model
{
    class FileDataRecord
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string HashSum { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastCheckTime { get; set; }

        public FileDataRecord(string filename)
        {
            FileName = filename;
            CreationTime = DateTime.Now;
        }
    }
}
