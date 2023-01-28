using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_Map.Entities
{
    public class Meci
    {
        public int Echipa1 { get; set; }
        public int Echipa2 { get; set; }

        public DateTime Date { get; set; }

        public int Id { get; set; }

        public Meci(int echipa1, int echipa2, DateTime date,int Id)
        {
            Echipa1 = echipa1;
            Echipa2 = echipa2;
            Date = date;
           this.Id = Id;
        }

        public override string? ToString()
        {
            return "id: "+Id+"Echipa 1: "+Echipa1+"Echipa 2:" + Echipa2+"Data: "+Date;
        }
    }
}
