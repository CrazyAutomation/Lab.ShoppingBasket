using System.Collections.Generic;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL.Repositories
{
    public interface ILoyaltyOfferRepository
    {
        IEnumerable<LoyaltyOffer> GetLoyaltyOffers();
        LoyaltyOffer GetLoyaltyOffer(int id);
    }
}
