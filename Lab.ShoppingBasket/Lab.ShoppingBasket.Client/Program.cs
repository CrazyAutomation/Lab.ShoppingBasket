using Lab.ShoppingBasket.BLL;
using Lab.ShoppingBasket.BLL.Repositories;
using Lab.ShoppingBasket.DAL;
using Lab.ShoppingBasket.Service;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab.ShoppingBasket.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository();
            IBogoOfferRepository bogoOfferRepository = new BogoOfferRepository();
            IOfferVoucherRepository offerVoucherRepository = new OfferVoucherRepository();
            ILoyaltyOfferRepository loyaltyOfferRepository = new LoyaltyOfferRepository();

            ConsoleSetup(0);
            // Basket 0: Empty Shopping Basket
            var shoppingBasket = new BLL.ShoppingBasket();

            IBasketProcessorFactory basketProcessorFactory = new BasketProcessorFactory();
            var basketService = new BasketService(basketProcessorFactory);
            var basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket0 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket0 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            ConsoleSetup(1);
            /* Basket 1:
               1 Hat @ 10.50
               1 Jumper @ 54.65
               BOGOF offer on Product Category:Hats
               Total: £65.15 
           */
            shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    bogoOfferRepository.GetBogofOffer(1)
                }
            };
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(2));

            basketService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket1 - Total : £{basketServiceResponse.BasketTotal}");


            ConsoleSetup(2);
            /* Basket 2:
               2 Hat @ 10.50
               1 Jumper @ 54.65
               BOGOF offer on Product Category:Hats
               Total: £65.15 
               Message: BOGOF discount £10.50 applied
           */
            shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    bogoOfferRepository.GetBogofOffer(1)
                }
            };
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(2));

            basketService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket2 - Total : £{basketServiceResponse.BasketTotal}");
            Console.WriteLine($"Basket2 - Message:{basketServiceResponse.Notifications.ToList().FirstOrDefault()}");

            ConsoleSetup(3);
            /* Basket 3:
               3 Hat @ 10.50
               1 Jumper @ 54.65
               BOGOF offer on Product Category:Hats
               Total: £75.65 
               Message: BOGOF discount £10.50 applied
           */
            shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    bogoOfferRepository.GetBogofOffer(1)
                }
            };
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(1));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(2));

            basketService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket3 - Total : £{basketServiceResponse.BasketTotal}");
            foreach (var notification in basketServiceResponse.Notifications)
            {
                Console.WriteLine($"Basket3 - Message:{notification}");
            }

            ConsoleSetup(4);
            /* Basket 4:
               2 Hat @ 4.65
               1 Jumper @ 14.45
               BOGOF offer on Product Category:Hats
               10% off on totals greater than £20 (after BOGOF)
               Total: £19.10
               Message: BOGOF discount £4.65 applied
               Message: “You have not reached the spend threshold for voucher YYY-YYY. Spend another £0.91 or more to receive 10% off your basket total.”
           */
            shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    bogoOfferRepository.GetBogofOffer(1)
                },
                OfferVoucher = offerVoucherRepository.GetOffVoucher(2)
            };
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(3));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(3));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(4));

            basketService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket4 - Total : £{basketServiceResponse.BasketTotal}");
            foreach (var notification in basketServiceResponse.Notifications)
            {
                Console.WriteLine($"Basket4 - Message:{notification}");
            }

            ConsoleSetup(5);
            /* Basket 5:
               2 Hat @ 6.70
               2 Jumper @ 12.65
               BOGOF offer on Product Category:Hats
               10% off on totals greater than £20 (after BOGOF) Applied
               Total: £28.80
               Message: BOGOF discount £6.70 applied
               Message: OfferVoucher discount £3.20 applied.               
           */
            shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    bogoOfferRepository.GetBogofOffer(1)
                },
                OfferVoucher = offerVoucherRepository.GetOffVoucher(2)
            };
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(8));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(8));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(11));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(11));

            basketService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket5 - Total : £{basketServiceResponse.BasketTotal}");
            foreach (var notification in basketServiceResponse.Notifications)
            {
                Console.WriteLine($"Basket5 - Message:{notification}");
            }

            ConsoleSetup(6);
            /* Basket 6:
               3 Hat @ 4.75
               2 Jumper @ 15.25
               BOGOF offer fon Product Category:Hats
               10% off on totals greater than £20 (after BOGOF) Applied
               Total: £26.10
               Message: BOGOF discount £4.75 applied
               Message: OfferVoucher discount £4.00 applied.
               Message: Loyalty discount £0.72 applied.               
           */
            shoppingBasket = new BLL.ShoppingBasket
            {
                BogofOffers = new List<BogofOffer>
                {
                    bogoOfferRepository.GetBogofOffer(1)
                },
                OfferVoucher = offerVoucherRepository.GetOffVoucher(2),
                LoyaltyOffer = loyaltyOfferRepository.GetLoyaltyOffer(1)
            };
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(10));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(10));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(10));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(9));
            shoppingBasket.AddtemToBasket(productRepository.GetProduct(9));

            basketService = new BasketService(basketProcessorFactory);
            basketServiceResponse = basketService.GetBasketTotal(shoppingBasket);

            Console.WriteLine($"Basket6 - Total : £{basketServiceResponse.BasketTotal}");
            foreach (var notification in basketServiceResponse.Notifications)
            {
                Console.WriteLine($"Basket6 - Message:{notification}");
            }
            Console.ReadLine();
        }

        private static void ConsoleSetup(int scenarioId)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"******** {scenarioId} ******************");
            Console.BackgroundColor = ConsoleColor.Black;

        }
    }
}
