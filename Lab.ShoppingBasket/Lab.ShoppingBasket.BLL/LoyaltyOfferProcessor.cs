using System;
using Lab.ShoppingBasket.Utilities.Extensions.DataTypes.Decimal;

namespace Lab.ShoppingBasket.BLL
{
    public class LoyaltyOfferProcessor : IBasketProcessor
    {
        public IShoppingBasket Process(IShoppingBasket shoppingBasket)
        {
            if (shoppingBasket.LoyaltyOffer == null) return shoppingBasket;

            decimal loyaltyOfferDiscount = decimal.Round(shoppingBasket.Total *
                                    shoppingBasket.LoyaltyOffer.PercentageOffDiscount.ConvertPercentToDecimal(),2,MidpointRounding.AwayFromZero);

            shoppingBasket.Total -= loyaltyOfferDiscount;
            shoppingBasket.Messages.Add($"Loyalty discount £{loyaltyOfferDiscount} applied.");
            return shoppingBasket;
        }
    }
}
