using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncriptadorDES
{
    class GeneradorLlave
    {
        static Random random = new Random();
        public string Generar()
        {
            byte[] buffer = new byte[32 / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (32 % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }
    }
}
