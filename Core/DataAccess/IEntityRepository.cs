
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
// CORE KATMANI BAŞKA KATMANLARI REFERANS ALMAZ !! EVRENSEL OLMALIDIR
namespace Core.DataAccess  // namespace = class'lar ve interfaceler belirli bir isim uzayına eklenir.
{
   // T = generics 
   // Burda kullandığımız yapı : Generic Repository Design Pattern
   // class : referans tip olabilir demek
   //IEntity : IEntity veya IEntity implemente eden bir nesne olabilir.
   // new() : can be "new", Interfaces cannot be new.
    public interface IEntityRepository<T> where T:class,IEntity,new() // T'ye yazılacakları kısıtlandırdık (Generic Constraint)
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); // Expression yapısı = Filtreleme yapmamızı sağlayan kod.bir LINQ yapısı.filter=null yazmamızın sebebi; filtre vermeyedebiliriz. 
        T Get(Expression<Func<T, bool>> filter); // Örneğin Tek bir banka hesabını getirmek için kullanırız.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
