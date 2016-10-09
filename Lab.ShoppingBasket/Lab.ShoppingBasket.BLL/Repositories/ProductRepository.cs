using System.Collections.Generic;
using System.Linq;
using Lab.ShoppingBasket.DAL;
using Lab.ShoppingBasket.Utilities.Enumerations.Product;

namespace Lab.ShoppingBasket.BLL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IEnumerable<Product> _products;

        public ProductRepository()
        {
            LoadProducts();
        }

        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        private void LoadProducts()
        {
            _products = new List<Product>
            {
                new Product {Id =1, Name ="Hat",Price=10.50m,ProductCategory = Category.Hats },
                new Product {Id =2,Name ="Jumper",Price=54.65m,ProductCategory = Category.Clothes },
                new Product {Id =3,Name ="Hat",Price=4.65m,ProductCategory = Category.Hats },
                new Product {Id =4,Name ="Jumper",Price=14.45m,ProductCategory = Category.Clothes },
                new Product {Id =5,Name ="Head Light",Price=3.50m,ProductCategory = Category.HeadGear },
                new Product {Id =6,Name ="Gift Voucher",Price=30.00m,ProductCategory = Category.GiftVoucher},
                new Product {Id =7,Name ="Hat",Price=10.50m,ProductCategory = Category.Hats},
                new Product {Id =8,Name ="Hat",Price=6.70m,ProductCategory = Category.Hats},
                new Product {Id =9,Name ="Jumper",Price=15.25m,ProductCategory = Category.Clothes },
                new Product{Id =10,Name ="Hat",Price=4.75m,ProductCategory = Category.Hats},
                new Product {Id =11,Name ="Jumper",Price=12.65m,ProductCategory = Category.Clothes },
            };

        }
    }
}
