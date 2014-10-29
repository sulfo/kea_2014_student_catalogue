using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalog.UnitTestExample
{
    public class DiscountRules
    {
        public int ApplyDiscount(int price)
        {
            if (price < 0)
                throw new Exception();

            int discount = 0;
            if (price >= 100 && price <= 500)
            {
                discount = 10;
            }
            else if (price > 500)
            {
                discount = 15;
            }

            return discount;
        }
    }
}