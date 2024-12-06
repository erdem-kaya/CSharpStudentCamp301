using CSharpStudentCamp301.DataAccessLayer.Abstract;
using CSharpStudentCamp301.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudentCamp301.DataAccessLayer.Respositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        CampContext context = new CampContext();
        private readonly DbSet<T> _object;

        public GenericRepository()
        {
            // Object is a DbSet<T> object that is used to access the database. 
            _object = context.Set<T>();
        }
        public void Delete(T entity)
        {
            var deletedEntity = context.Entry(entity);
            // The EntityState property of the Entry object is set to Deleted to delete the entity.
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T entity)
        {
            var addedEntity = context.Entry(entity);
            // The EntityState property of the Entry object is set to Added to add the entity.
            addedEntity.State = EntityState.Added;
            context.SaveChanges();

        }

        public void Update(T entity)
        {
            var updatedEntity = context.Entry(entity);
            // The EntityState property of the Entry object is set to Modified to update the entity.
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
