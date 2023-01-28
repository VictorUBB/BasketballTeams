using lab8_Map.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_Map.repository
{
   

   public class FileRepoJucator<ID, E> : InMemoryRepository<ID, E> where E : Jucator
    {
        protected string fileName;
        protected CreateEntity<E> createEntity;

        public FileRepoJucator(String fileName, CreateEntity<E> createEntity)
        {
            this.fileName = fileName;
            this.createEntity = createEntity;
            if (createEntity != null)
                loadFromFile();
        }

        protected virtual void loadFromFile()
        {
            List<E> list = DataReader.ReadData(fileName, createEntity);
            list.ForEach(x => entities[x.Id] = x);
        }


    }
}
