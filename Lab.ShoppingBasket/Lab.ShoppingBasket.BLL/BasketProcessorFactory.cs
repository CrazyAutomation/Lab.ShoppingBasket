
namespace Lab.ShoppingBasket.BLL
{
    public class BasketProcessorFactory : IBasketProcessorFactory
    {

        public IBasketProcessor CreateBogofOfferProcessor()
        {
            return  new BogofOfferProcessor();
        }

        public IBasketProcessor CreateOfferVoucherProcessor()
        {
            return new OfferVoucherProcessor();
        }

        public IBasketProcessor CreateLoyaltyOfferProcessor()
        {
            return new LoyaltyOfferProcessor();
        }

        public IBasketProcessor CreateProductProcessor()
        {
            return  new ProductProcessor();
        }
    }
}
