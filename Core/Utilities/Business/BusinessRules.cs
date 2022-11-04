using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) // params verdiğimiz zaman Run methodu içine istediğimiz kadar IResult verebiliyoruz parametre olarak.logics iş kuralları fonksiyonları demek
        {
            foreach (var logic in logics)
            {
                if (!logic.Success) // başarısız olanı business'e bildiriyoruz.
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
