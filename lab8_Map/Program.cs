using lab8_Map.console;
using lab8_Map.Entities;
using lab8_Map.repository;
using lab8_Map.service;
using lab8_Map.validator;

namespace lab8_Map
{
    class Program
    {
        static void Main(string[] args)
        {

            /*            Service service = new Service(new FileRepoElev<int, Elev>("..\\..\\..\\data\\elev.txt",EntityToFile.CreateElev));
                        IList<Jucator> ju = service.GetJucatorListByTeam("Milwaukee Bucks");
                        ju.ToList().ForEach(Console.WriteLine);*/

            Service service = new Service(new FileRepoElev<int, Elev>("..\\..\\..\\data\\JucatorActiv.txt", EntityToFile.CreateElev), new FileRepoJucator<int, Jucator>("..\\..\\..\\data\\jucatori.txt", EntityToFile.CreateJucator),
                new ActivFileRepo<int, JucatorActiv>("..\\..\\..\\data\\JucatorActiv.txt", EntityToFile.CreateJucatorActiv), new FileRepoMeci<int, Meci>("..\\..\\..\\data\\Meci.txt", EntityToFile.CreateMeci),new FileRepoEchipa<int, Echipa>("..\\..\\..\\data\\echipe.txt", EntityToFile.CreateEchipa));
            UI ui = new UI(service);
            ui.run();
            
        }
    }
}
