using lab8_Map.Entities;
using lab8_Map.repository;
using lab8_Map.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab8_Map.service
{
    public class Service
    {
        private IRepository<int, Elev> elevRepo;
        private IRepository<int, Jucator> jucatorRepo;//=new FileRepoJucator<int,Jucator>("..\\..\\..\\data\\jucatori.txt",EntityToFile.CreateJucator);
        private IRepository<int, JucatorActiv> activrepo;// = new ActivFileRepo<int, JucatorActiv>("..\\..\\..\\data\\JucatorActiv.txt", EntityToFile.CreateJucatorActiv);
        private IRepository<int, Meci> meciRepo;// = new FileRepoMeci<int, Meci>("..\\..\\..\\data\\jucatori.txt", EntityToFile.CreateMeci);
        private IRepository<int, Echipa> echipaRepo;// = new FileRepoEchipa<int, Echipa>("..\\..\\..\\data\\echipe.txt", EntityToFile.CreateEchipa);

        public Service(IRepository<int, Elev> elevRepo, IRepository<int, Jucator> jucatorRepo, IRepository<int, JucatorActiv> activrepo, IRepository<int, Meci> meciRepo, IRepository<int, Echipa> echipaRepo)
        {
            this.elevRepo = elevRepo;
            this.jucatorRepo = jucatorRepo;
            this.activrepo = activrepo;
            this.meciRepo = meciRepo;
            this.echipaRepo = echipaRepo;
        }

        public List<Elev> GetElevList() { return elevRepo.FindAll().ToList(); }

        public List<Meci> GetMeciList() { return meciRepo.FindAll().ToList();}

        

        public List<Echipa> GetEchipaList() { return echipaRepo.FindAll().ToList(); }
        public List<Jucator> GetJucatorListByTeam(int team)
        {
            List<Jucator> jucators=jucatorRepo.FindAll().ToList().Where(x => x.id_echipa == team).ToList();
            return jucators;
        }

        public List<Jucator> GetJucatorFromMeci(int meciId,int echipa) 
        {
            IList<JucatorActiv> jucActiv = activrepo.FindAll().ToList().Where(x => x.IdMeci == meciId).ToList();
            List<Jucator> jucatorii = new List<Jucator>();
            foreach(JucatorActiv jucator in jucActiv.ToList())
            {
                Jucator juc = jucatorRepo.FindOne(jucator.Id);
                if(juc.id_echipa==echipa)
                {
                    jucatorii.Add(juc);
                }
            }
            return jucatorii;
        }

        public List<Meci> GetMeciByDates(DateTime startDate,DateTime endDate)
        {
            List<Meci> mecis = meciRepo.FindAll().ToList().Where(x =>  x.Date > startDate&&x.Date<endDate).ToList();

            return mecis;
        }

        public Echipa findTeam(int id) { return echipaRepo.FindOne(id); }

        public void getMatchResult(int id_meci)
        {
            Meci meci = meciRepo.FindOne(id_meci);
            int sum_team1 = 0;
            int sum_team2 = 0;

            List<JucatorActiv> jucList=activrepo.FindAll().ToList().Where(x => x.IdMeci==id_meci).ToList();

            foreach(JucatorActiv jucator in jucList)
            {
                if (jucatorRepo.FindOne(jucator.id_jucatr).id_echipa == meci.Echipa1)
                    sum_team1 += jucator.nrPuncte;

                if (jucatorRepo.FindOne(jucator.id_jucatr).id_echipa == meci.Echipa2)
                {
                    sum_team2+= jucator.nrPuncte;
                }
            }

            Console.WriteLine(echipaRepo.FindOne(meci.Echipa1) + " " + sum_team1 + " / "+echipaRepo.FindOne(meci.Echipa2) + " " + sum_team2);

        }
    }
}
