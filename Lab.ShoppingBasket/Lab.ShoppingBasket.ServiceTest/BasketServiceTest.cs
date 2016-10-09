using System.Collections.Generic;
using Lab.ShoppingBasket.BLL;
using Lab.ShoppingBasket.BLL.Repositories;
using Lab.ShoppingBasket.DAL;
using Lab.ShoppingBasket.Service;
using NUnit.Framework;

namespace Lab.ShoppingBasket.ServiceTest
{
    [TestFixture]
    public class BasketServiceTest
    {
        private IProductRepository _productRepository;
        private IBogoOfferRepository _bogoOfferRepository;
        private IOfferVoucherRepository _offerVoucherRepository;
        private ILoyaltyOfferRepository _loyaltyOfferRepository;
        private IBasketProcessorFactory _basketProcessorFactory;


        [OneTimeSetUp]
        public void TestSetup()
        {
            _productRepository = new ProductRepository();
            _bogoOfferRepository = new BogoOfferRepository();
            _offerVoucherRepository = new OfferVoucherRepository();
            _loyaltyOfferRepository = new LoyaltyOfferRepository();
            _basketProcessorFactory = new BasketProcessorFactory();
        }

        /// <summary>
        /// Scenario : Basket1
        /// Given Products 1 Hat @ £10.50 and 1 Jumper @ £54.65
        /// And BOGOF offer on Product Category : Hats
        /// When I call BasketService.GetBasketTotal()
        /// Then Basket Total : £65.15
        /// </summary>
        [Test]
        public void Test_Basket1()
        {
            // Arrage
            var shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    _bogoOfferRepository.GetBogofOffer(1)
                }
            };
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(2));

            var basketService = new BasketService(_basketProcessorFactory);

            // Act
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            // Assert
            Assert.AreEqual(65.15, basketServiceResponse.BasketTotal);
            Assert.AreEqual(0, basketServiceResponse.Notifications.Count);
        }

        /// <summary>
        /// Scenario : Basket2
        /// Given Products 2 Hat @ £10.50 and 1 Jumper @ £54.65
        /// And BOGOF offer on Product Category : Hats
        /// When I call BasketService.GetBasketTotal()
        /// Then Basket Total : £65.15
        /// Then Message : BOGOF discount £10.50 applied
        /// </summary>
        [Test]
        public void Test_Basket2()
        {

            // Arrage
            var shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    _bogoOfferRepository.GetBogofOffer(1)
                }
            };
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(2));

            var basketService = new BasketService(_basketProcessorFactory);

            // Act
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            // Assert
            Assert.AreEqual(65.15, basketServiceResponse.BasketTotal);
            Assert.AreEqual(1, basketServiceResponse.Notifications.Count);

        }

        /// <summary>
        /// Scenario : Basket3
        /// Given Products 3 Hat @ £10.50 and 1 Jumper @ £54.65
        /// And BOGOF offer on Product Category : Hats
        /// When I call BasketService.GetBasketTotal()
        /// Then Basket Total : £75.65
        /// Then Message : BOGOF discount £10.50 applied
        /// </summary>
        [Test]
        public void Test_Basket3()
        {
            // Arrage
            var shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    _bogoOfferRepository.GetBogofOffer(1)
                }
            };
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(2));

            var basketService = new BasketService(_basketProcessorFactory);

            // Act
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            // Assert
            Assert.AreEqual(75.65, basketServiceResponse.BasketTotal);
            Assert.AreEqual(1, basketServiceResponse.Notifications.Count);
        }

        /// <summary>
        /// Scenario : Basket4
        /// Given Products 2 Hat @ £4.65 and 1 Jumper @ £14.45
        /// And BOGOF offer on Product Category : Hats
        /// And 10% off on totals greater than £20
        /// When I call BasketService.GetBasketTotal()
        /// Then Basket Total : £19.10
        /// Then Message : BOGOF discount £4.65 applied
        /// Then Message:“You have not reached the spend threshold for voucher YYY-YYY. Spend another £0.91 or more to receive 10% off your basket total.”
        /// </summary>
        [Test]
        public void Test_Basket4()
        {
            // Arrage
            var shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    _bogoOfferRepository.GetBogofOffer(1)
                },
                OfferVoucher = _offerVoucherRepository.GetOffVoucher(2)
            };
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(3));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(3));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(4));

            var basketService = new BasketService(_basketProcessorFactory);

            // Act
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            // Assert
            Assert.AreEqual(19.10, basketServiceResponse.BasketTotal);
            Assert.AreEqual(2, basketServiceResponse.Notifications.Count);
        }

        /// <summary>
        /// Scenario : Basket5
        /// Given Products 2 Hat @ £6.70 and 2 Jumper @ £12.65
        /// And BOGOF offer on Product Category : Hats
        /// And 10% off on totals greater than £20
        /// When I call BasketService.GetBasketTotal()
        /// Then Basket Total : £28.80
        /// Then Message : BOGOF discount £6.70 applied
        /// Then Message:OfferVoucher discount £3.20 applied. 
        /// </summary>
        [Test]
        public void Test_Basket5()
        {
            // Arrage
            var shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    _bogoOfferRepository.GetBogofOffer(1)
                },
                OfferVoucher = _offerVoucherRepository.GetOffVoucher(2)
            };
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(8));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(8));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(11));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(11));

            var basketService = new BasketService(_basketProcessorFactory);

            // Act
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            // Assert
            Assert.AreEqual(28.80, basketServiceResponse.BasketTotal);
            Assert.AreEqual(2, basketServiceResponse.Notifications.Count);
        }


        /// <summary>
        /// Scenario : Basket6
        /// Given Products 3 Hat @ £4.75 and 2 Jumper @ £15.25
        /// And BOGOF offer on Product Category : Hats
        /// And 10% off on totals greater than £20
        /// When I call BasketService.GetBasketTotal()
        /// Then Basket Total : £35.28
        /// Then Message : BOGOF discount £4.75 applied
        /// Then Message:OfferVoucher discount £4.00 applied. 
        /// Message: Loyalty discount £0.72 applied.  
        /// </summary>
        [Test]
        public void Test_Basket6()
        {
            // Arrage
            var shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    _bogoOfferRepository.GetBogofOffer(1)
                },
                OfferVoucher = _offerVoucherRepository.GetOffVoucher(2),
                LoyaltyOffer = _loyaltyOfferRepository.GetLoyaltyOffer(1)
            };
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(10));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(10));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(10));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(9));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(9));

            var basketService = new BasketService(_basketProcessorFactory);

            // Act
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            // Assert
            Assert.AreEqual(35.28, basketServiceResponse.BasketTotal);
            Assert.AreEqual(3, basketServiceResponse.Notifications.Count);

        }

    }
}
