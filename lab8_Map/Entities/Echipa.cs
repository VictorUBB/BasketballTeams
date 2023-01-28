using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_Map.Entities
{
    public class Echipa
    {
        public int Id { get; set; }
        public string name { get; set; }

        public Echipa(int id, string name)
        {
            this.Id = id;
            this.name = name;
        }

        public override string? ToString()
        {
            return Id+" "+name;
        }
    }
}
