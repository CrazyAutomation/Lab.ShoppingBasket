using System;
using Lab.ShoppingBasket.Utilities.Enumerations.Product;

namespace Lab.ShoppingBasket.DAL
{
    public class BogofOffer
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Category ProductCategory { get; set; }

        public static explicit operator BogofOffer(Category v)
        {
            throw new NotImplementedException();
        }
    }
}
