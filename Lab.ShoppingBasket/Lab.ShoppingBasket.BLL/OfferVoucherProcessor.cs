using System;
using Lab.ShoppingBasket.Utilities.Enumerations.Voucher;
using Lab.ShoppingBasket.Utilities.Extensions.DataTypes.Decimal;

namespace Lab.ShoppingBasket.BLL
{
    public class OfferVoucherProcessor : IBasketProcessor
    {
        public IShoppingBasket Process(IShoppingBasket shoppingBasket)
        {
            if (shoppingBasket.OfferVoucher == null) return shoppingBasket;

            if (!ValidateOfferVoucherForThreshold(shoppingBasket)) return shoppingBasket;

            if (shoppingBasket.OfferVoucher.OfferVoucherType != OfferVoucherType.Basket) return shoppingBasket;

            
            decimal offerVoucherDiscount = decimal.Round(shoppingBasket.Total*
                                           shoppingBasket.OfferVoucher.PercentageOffDiscount.ConvertPercentToDecimal(),2,MidpointRounding.AwayFromZero);
            shoppingBasket.Total -= offerVoucherDiscount;
            shoppingBasket.Messages.Add($"OfferVoucher discount £{offerVoucherDiscount} applied.");

            return shoppingBasket;
        }

        private static bool ValidateOfferVoucherForThreshold(IShoppingBasket basket)
        {
            var basketsTotal = basket.Total;

            if (basketsTotal >= basket.OfferVoucher.Threshold) return true;

            var additonalAmountToSpend = basket.OfferVoucher.Threshold - basketsTotal + 0.01m;
            basket.Messages.Add($"You have not reached the spend threshold for voucher {basket.OfferVoucher.Code}. Spend another £{additonalAmountToSpend} to receive 10% off on your basket totals.");

            return false;
        }

    }
}
