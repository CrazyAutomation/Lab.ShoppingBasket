using System.Collections.Generic;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL
{
    public interface IShoppingBasket
    {
        IEnumerable<BogofOffer> BogofOffers { get; set; }
        OfferVoucher OfferVoucher { get; set; }
        LoyaltyOffer LoyaltyOffer { get; set; }
        IEnumerable<BasketItem> GetBasketItems();
        IList<string> Messages { get; set; }
        void AddtemToBasket(Product product);
        void RemoveItemFromBasket(Product product);
        void EmptyBasketItems();
        decimal Total { get; set; }
    }
}
