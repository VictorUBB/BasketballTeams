using lab8_Map.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_Map.repository
{
   public  class ActivFileRepo<ID, E> : IRepository<ID, E> where E : JucatorActiv
    {
        protected string fileName;
        protected CreateEntity<E> createEntity;

        public ActivFileRepo(String fileName, CreateEntity<E> createEntity)
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

        protected IDictionary<int, E> entities = new Dictionary<int, E>();



        public E Delete(ID id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<E> FindAll()
        {
            return entities.Values.ToList<E>();
        }

        public E FindOne(ID id)
        {
            throw new NotImplementedException();
        }

        public E Save(E entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity must not be null");

            if (this.entities.ContainsKey(entity.Id))
            {
                return entity;
            }
            this.entities[entity.Id] = entity;
            return default(E);
        }

        public E Update(E entity)
        {
            throw new NotImplementedException();
        }
    }
}
