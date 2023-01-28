using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_Map.Entities
{
    public class Elev
    {
        public int Id { get; set; }
        public String Nume { get; set; }
        public String Scoala { get; set; }

        public Elev(int id, string nume, string scoala)
        {
            Id = id;
            Nume = nume;
            Scoala = scoala;
        }
    }
}
