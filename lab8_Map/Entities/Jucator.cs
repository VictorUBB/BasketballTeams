using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_Map.Entities
{
    public class Jucator : Elev 
    {
        public int id_echipa { set; get; }

        public Jucator(int id, string nume, string scoala,int echipa) : base(id, nume, scoala)
        {
            this.id_echipa = echipa;
        }

        public override string ToString()
        {
            return this.Nume + " " + Scoala + " " + id_echipa;
        }
    }
}
