using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xr_Sec.Helpful;
using Xr_Sec.Model;

namespace Xr_Sec
{
    class Watchman //отслеживает изменения файловой системы, пока обрабатывает только OnChange
    {
        protected readonly FileSystemWatcher watcher;
        protected readonly HashCoder hashCoder = new HashCoder();
        protected readonly object writeLock = new object();
        protected readonly MailSender mailSender = new MailSender();
        
        protected bool enabled = true;
        public Watchman()
        {
            watcher = new FileSystemWatcher("D:\\Xr-Sec\\Test");
            watcher.Filter = "Newfag.txt";
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enabled)
            {
                Thread.Sleep(1000);
            }
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;
        }
        // переименование файлов
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fileEvent = " переименован в " + e.FullPath;
            string filePath = e.OldFullPath;
            //RecordEntry(fileEvent, filePath);
        }
        // изменение файлов
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            lock (writeLock)
            {
                using (DataContext dbcontext = new DataContext())
                {
                    var NewRecord = new FileDataRecord(e.FullPath);
                    NewRecord.HashSum = hashCoder.SHAEncode(e.FullPath);
                    lock(writeLock) //отправить уведомление на почту + записать в базу (не работает)
                    {
                        mailSender.MailSend(NewRecord);
                        dbcontext.FileDataRecords.Add(NewRecord);
                    }                    
                }
            }            
        }
        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string filePath = e.FullPath;
            //dbTalker.DBPush(filePath);
        }
        // удаление файлов
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "удален ";
            string filePath = e.FullPath;
            //RecordEntry(fileEvent,  filePath);
        }
       
    }
}
