using System.Linq;

namespace Lab.ShoppingBasket.BLL
{
    public class BogofOfferProcessor : IBasketProcessor
    {

        public IShoppingBasket Process(IShoppingBasket shoppingBasket)
        {
            if (!shoppingBasket.BogofOffers.Any())
                return shoppingBasket;

            foreach (var basketItem in shoppingBasket.GetBasketItems())
            {
                if (basketItem.Quantity < 2) continue;

                if (shoppingBasket.BogofOffers.All(bogof => bogof.ProductCategory != basketItem.Product.ProductCategory))
                    continue;

                var quantityTodrop = basketItem.Quantity / 2;
                var bogofOfferDiscount = quantityTodrop * basketItem.Product.Price;
                shoppingBasket.Total -= bogofOfferDiscount;
                shoppingBasket.Messages.Add($"BOGOF discount £{bogofOfferDiscount} applied.");

            }

            return shoppingBasket;
        }

    }
}
   

