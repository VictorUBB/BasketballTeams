using lab8_Map.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_Map.repository
{
  public  class InMemoryRepository<ID, E> : IRepository<int, E> where E : Elev
    {
       

        protected IDictionary<int, E> entities = new Dictionary<int, E>();



        public E Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<E> FindAll()
        {
            return entities.Values.ToList<E>();
        }

        public E FindOne(int id)
        {
            if(id!= null)
            {
                entities.TryGetValue(id, out E entity);
                return entity;
            }

            return null;
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
