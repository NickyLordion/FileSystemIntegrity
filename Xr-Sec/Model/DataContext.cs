using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xr_Sec.Model
{
    class DataContext : DbContext //TODO подключить MS SQL Server
    {
        public DbSet<FileDataRecord> FileDataRecords { get; set; }
    }
}
