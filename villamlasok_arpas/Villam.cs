using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace villamlasok_arpas
{
    internal class Villam
    {
        public int Nap { get; set; }
        public List<int> Orak { get; set; }

        public Villam(string sor, int index) {
            var d = sor.Split(";");
            Nap = index + 1;
            Orak = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                Orak.Add(int.Parse(d[i]));
            }
        }

        public override string ToString()
        {
            return $"{Nap}. nap: {string.Join(" ", Orak)}";
        }
    }
}
