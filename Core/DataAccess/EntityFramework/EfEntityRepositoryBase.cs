using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    //Entity framework kullanarak repository base'i oluşturuyoruz
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c# : using bittiği an belleği temizleme, normalde garbage collector beliri periyotlarla temizler.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // Referansı eşleştirme.(Aslında add işleminde gerek yok)
                addedEntity.State = EntityState.Added; // ekle
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); // Referansı eşleştirme.
                deletedEntity.State = EntityState.Deleted; // sil
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);


            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
                // filtre nullsa ilk satır değilse 2. satırda filtreyi kullandırır
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); // Referansı eşleştirme.
                updatedEntity.State = EntityState.Modified; // sil
                context.SaveChanges();
            }
        }
    }
}
