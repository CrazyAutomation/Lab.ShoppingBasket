using System.Collections.Generic;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL.Repositories
{
    public interface IBogoOfferRepository
    {
        IEnumerable<BogofOffer> GetBogofOffers();
        BogofOffer GetBogofOffer(int id);
    }
}
