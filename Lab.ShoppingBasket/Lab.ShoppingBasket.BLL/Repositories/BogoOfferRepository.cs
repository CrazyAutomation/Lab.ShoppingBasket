using System.Collections.Generic;
using System.Linq;
using Lab.ShoppingBasket.DAL;
using Lab.ShoppingBasket.Utilities.Enumerations.Product;


namespace Lab.ShoppingBasket.BLL.Repositories
{
    public class BogoOfferRepository : IBogoOfferRepository
    {

        private IEnumerable<BogofOffer> _bogoOfferRepositories;

        public BogoOfferRepository()
        {
            LoadBogoOfferRepositories();
        }

        public BogofOffer GetBogofOffer(int id)
        {
            return _bogoOfferRepositories.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<BogofOffer> GetBogofOffers()
        {
            return _bogoOfferRepositories;
        }

        private void LoadBogoOfferRepositories()
        {
            _bogoOfferRepositories = new List<BogofOffer>
            {
                new BogofOffer
                {
                    Id = 1,
                    Code = "XXX-XXX",
                    ProductCategory = Category.Hats
                },

                new BogofOffer
                {
                    Id = 2,
                    Code = "XXX-XXX",
                    ProductCategory = Category.Clothes
                },
                new BogofOffer
                {
                    Id = 3,
                    Code = "XXX-XXX",
                    ProductCategory = Category.HeadGear
                },

            };
        }
    }
}
