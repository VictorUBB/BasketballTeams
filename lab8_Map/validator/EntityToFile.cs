using lab8_Map.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_Map.validator
{
    public class EntityToFile
    {
        public static Elev CreateElev(string line)
        {
            string[] fields=line.Split  (';');
            Elev elev = new Elev(int.Parse(fields[0]), fields[1], fields[2]);
            return elev;

        }
        public static Jucator CreateJucator(string line) {
            string[] fields=line.Split (";");
            ;
            Jucator jucator=new Jucator(int.Parse(fields[0]), fields[1], fields[2], int.Parse(fields[3]));
            return jucator;
        }

        public static Meci CreateMeci(string line)
        {
            string[] fields=line.Split (";");

            Meci meci=new Meci(int.Parse(fields[1]), int.Parse(fields[2]), DateTime.ParseExact(fields[3],"dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture), int.Parse(fields[0]));
            return meci;
        }


        public static JucatorActiv CreateJucatorActiv(string line)
        {
            string[] fields=line.Split (";");
            if (fields[4] == "Rezerva")
            {
                JucatorActiv jucatorActiv = new JucatorActiv(int.Parse(fields[0]), int.Parse(fields[1]), int.Parse(fields[2]), int.Parse(fields[3]), tipJucator.Rezerva);
                return jucatorActiv;
            }
            else
            {
                JucatorActiv jucatorActiv = new JucatorActiv(int.Parse(fields[0]), int.Parse(fields[1]), int.Parse(fields[2]), int.Parse(fields[3]), tipJucator.Participant);
                return jucatorActiv;           
            } 


        }   
        public static Echipa CreateEchipa(string line)
        {
            string[] fields = line.Split(";");
            Echipa ech = new Echipa(int.Parse(fields[0]), fields[1]);
            return ech;
        }
    }



}
