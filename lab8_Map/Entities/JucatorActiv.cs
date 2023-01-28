using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_Map.Entities
{
    public enum tipJucator
    {
        Rezerva=1,Participant
    }
  public  class JucatorActiv
    {
        public int Id { get; set; }
        public int IdMeci { get; set; }
        public int nrPuncte { get; set; }

        public int id_jucatr { get; set; }
        public tipJucator tipJucator { get; set; }

        public JucatorActiv(int id,int id_jucator, int idMeci, int nrPuncte, tipJucator tipJucator)
        {
            Id = id;
            IdMeci = idMeci;
            this.id_jucatr = id_jucator;
            this.nrPuncte = nrPuncte;
            this.tipJucator = tipJucator;
        }
    }
}
