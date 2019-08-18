using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parallel
{
    // buuu ortak fonksiyonlar falan burda toplancak
    public class localmethods
    {

        //min max aralığında double random fonksiyonu
        public static double Randomic(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

    }
}
