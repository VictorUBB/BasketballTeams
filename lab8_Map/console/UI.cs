using lab8_Map.Entities;
using lab8_Map.service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_Map.console
{
    public class UI
    {
        private Service service;

        public UI(Service service)
        {
            this.service = service;
        }


        public void showOptions()
        {
            Console.WriteLine("1. Afisati jucatorii unei echipe");
            Console.WriteLine("2. Afisati jucatori activi al unei echipe de la un meci");
            Console.WriteLine("3. Afisati meciurile dinre-o perioada calendristica");
            Console.WriteLine("4. Afisati scorul unui meci");
        }

        public void run()
        {
            while (true)
            {
                showOptions();
                int option = int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:showTeamMembers();
                        break;
                    case 2:showActivePlayers(); break;
                        case 3:showMatchFromTime(); break;
                    case 4:showResults(); break;

                }
            }
        }
        public void showTeamMembers()
        {
            List<Echipa> echipas = service.GetEchipaList();
            echipas.ForEach(Console.WriteLine);


            Console.WriteLine("Alegeti echipa");
            int id = int.Parse(Console.ReadLine());
            service.GetJucatorListByTeam(id).ForEach(Console.WriteLine);

        }


        public void showActivePlayers()
        {
            List<Echipa> echipas = service.GetEchipaList();
            echipas.ForEach(Console.WriteLine);
            Console.WriteLine("Alegeti echipa");
            int id = int.Parse(Console.ReadLine());

            List<Meci> mecis= service.GetMeciList();

            foreach(Meci meci in mecis)
            {

                if (meci.Echipa1 == id)
                {
                    Console.WriteLine(meci);
                }

                if(meci.Echipa2 == id) { Console.WriteLine(meci);}

                
            }

            Console.WriteLine("Alegeti meciul: \n");
            int id_meci = int.Parse(Console.ReadLine());
            service.GetJucatorFromMeci(id_meci, id).ForEach(Console.WriteLine);
        }


        public void showMatchFromTime()
        {
            Console.WriteLine("Dati data de inceput: \n");
            DateTime stareDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.WriteLine("Dati data de final: \n");
            DateTime finalDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            service.GetMeciByDates(stareDate,finalDate).ForEach(Console.WriteLine);
        }

        public void showResults()
        {
            service.GetMeciList().ForEach(Console.WriteLine);
            Console.WriteLine("Alegeti meciul:");
            int id = int.Parse(Console.ReadLine()) ;
            service.getMatchResult(id);

        }
    }
}
