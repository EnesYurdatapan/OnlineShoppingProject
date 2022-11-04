using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages // new'lenmemesi için static yaptık.
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime="Sistem bakımda";
        public static string ProductsListed="ürünler listelendi";
        public static string ProductCountOfCategoryError="Aynı kategoriye 10 üründen fazla eklenemez.";
        public static string ProductNameAlreadyExists="Aynı isimde kayıt zaten var !";
        public static string CategoryLimitExceeded="Kategori limiti aşıldı !!";
        public static string AuthorizationDenied="Yetkiniz yok !";
        public static string ProductUpdated="Ürün başarıyla güncellendi !";
        public static string ProductDeleted = "Ürün silindi.";

    }
}
