using System.Collections.Generic;
using Lab.ShoppingBasket.BLL;
using Lab.ShoppingBasket.BLL.Repositories;
using Lab.ShoppingBasket.DAL;
using NUnit.Framework;

namespace Lab.ShoppingBasket.BLLTest
{
    [TestFixture]
    public class BogofOfferProcessorTest
    {

        private IProductRepository _productRepository;
        private IBogoOfferRepository _bogoOfferRepository;
        
        

        [OneTimeSetUp]
        public void TestSetup()
        {
            _productRepository = new ProductRepository();
            _bogoOfferRepository = new BogoOfferRepository();
        }

        /// <summary>
        /// Scenario : Basket1
        /// Given Products 1 Hat @ £10.50 and 1 Jumper @ £54.65
        /// And  BOGOF offer for Category:Hats XXX-XXX applied
        /// And Basket Total £65.15
        /// When I call BogofOfferProcessor.Process()
        /// Then Basket Total : £65.15
        /// </summary>
        [Test]
        public void Test_Verify_BasketTotal_After_Calling_BogofOfferProcessor_For_Basket1()
        {
            // Arrange
            var shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    _bogoOfferRepository.GetBogofOffer(3)
                }

            };
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(7));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(2));

            // Act
            var basketProcessor = new BogofOfferProcessor();
            shoppingBasket.Total = 65.15m;
            basketProcessor.Process(shoppingBasket);

            // Assert
            Assert.AreEqual(65.15m, shoppingBasket.Total);
        }


        /// <summary>
        /// Scenario : Basket2
        /// Given Products 2 Hat @ £10.50 and 1 Jumper @ £54.65
        /// And  BOGOF offer for Category:Hats XXX-XXX applied
        /// And Basket Total £75.65
        /// When I call BogofOfferProcessor.Process()
        /// Then Basket Total : £65.15
        /// </summary>
        [Test]
        public void Test_Verify_BasketTotal_After_Calling_BogofOfferProcessor_For_Basket2()
        {
            // Arrange
            var shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    _bogoOfferRepository.GetBogofOffer(1)
                }

            };
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(7));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(7));
            shoppingBasket.AddtemToBasket(_productRepository.GetProduct(2));

            // Act
            var basketProcessor = new BogofOfferProcessor();
            shoppingBasket.Total = 75.65m;
            basketProcessor.Process(shoppingBasket);

            // Assert
            Assert.AreEqual(65.15m, shoppingBasket.Total);
        }
    }
}
