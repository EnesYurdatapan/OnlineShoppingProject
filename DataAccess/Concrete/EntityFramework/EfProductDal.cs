using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

// ORM = Veritabanındaki tabloyu classmış gibi kullanıp sql sorgularını LINQ ile yazmamızı sağlar.ORM, veritabanı nesneleriyle kodlar arası bağ kurup veritabanı işlerini yapma sürecidir.OBJECT RELATİONAL MAPPİNG
namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock }; // sonucu bu kolonlardan al
                return result.ToList();
            }
            
            
        }
    }
}
