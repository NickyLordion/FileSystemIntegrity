using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xr_Sec
{
    /*
     * Класс для хэширования данных при помощи SHA256
     */
    class HashCoder
    {
        private SHA256 coder = SHA256.Create();

        public HashCoder()
        {
            coder.Initialize(); //помимо создания кодер для работы нужно инициализировать
        }
        public string SHAEncode (string filepath)
        {
            try //хэшируем весь файл из filepath, начиная с позиции 0, затем преобразуем массив char к string
            {
                if (coder == null)
                    coder = SHA256.Create();
                var stream = new FileStream(filepath, FileMode.Open);
                stream.Position = 0;
                var hashCode = coder.ComputeHash(stream);
                string _result = "";
                foreach (var item in hashCode)
                {
                    _result += item.ToString();
                }
                return _result;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Неверный путь к файлу!");
                return "";
            }
            
        }
    }
}
