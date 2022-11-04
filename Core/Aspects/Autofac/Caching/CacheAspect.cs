using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"); // Key değerini oluşturmak için methodun ismini alıyoruz.Reflected type : namespace ve Fullname eklentisi(Business.Concrete.IProductService
            var arguments = invocation.Arguments.ToList(); // methodun parametrelrerin listeye çevir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; // Eğer parametre varsa parantez içine ekler. // 2 soru işareti= 'varsa' soldakini, 'yoksa' sağdakini ekle demek.
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key); // ReturnValue=Return edilecek değeri belirler.Yani veri cache'te varsa return burdan alınır.
                return;
            }
            invocation.Proceed(); // cachete yoksa devam et
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
