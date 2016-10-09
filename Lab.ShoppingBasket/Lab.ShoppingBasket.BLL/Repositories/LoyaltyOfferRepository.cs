using System.Collections.Generic;
using System.Linq;
using Lab.ShoppingBasket.DAL;

namespace Lab.ShoppingBasket.BLL.Repositories
{
    public class LoyaltyOfferRepository : ILoyaltyOfferRepository
    {

        private IEnumerable<LoyaltyOffer> _loyaltyOffers;

        public LoyaltyOfferRepository()
        {
            LoadLoyaltyOffers();
        }

        public LoyaltyOffer GetLoyaltyOffer(int id)
        {
            return _loyaltyOffers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<LoyaltyOffer> GetLoyaltyOffers()
        {
            return _loyaltyOffers;
        }

        private void LoadLoyaltyOffers()
        {
            _loyaltyOffers = new List<LoyaltyOffer>
            {
                new LoyaltyOffer
                {
                    Id = 1,
                    Code = "ZZZ-ZZZ",
                    PercentageOffDiscount =2
                }

            };
        }
    }
}
