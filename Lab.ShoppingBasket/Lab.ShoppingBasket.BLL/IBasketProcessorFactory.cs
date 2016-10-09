
namespace Lab.ShoppingBasket.BLL
{
    public interface IBasketProcessorFactory
    {
        IBasketProcessor CreateProductProcessor();
        IBasketProcessor CreateBogofOfferProcessor();
        IBasketProcessor CreateOfferVoucherProcessor();
        IBasketProcessor CreateLoyaltyOfferProcessor();
    }
}
