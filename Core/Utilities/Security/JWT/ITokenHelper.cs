using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
  public  interface ITokenHelper // kullanıcı id pw girdikten sonra bu operasyon çalışır eğer doğruysa.Veritabanına gidecek, kullanıcı için claimleri bulacak, orada bir json web token üretecek ve buraya verecek
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
