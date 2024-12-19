using Checkout.Classes;
using Checkout.Interfaces;

namespace Checkout
{
    public class Checkout : ICheckout
    {
        public List<Product> Products { get; }
        List<BasketItem> basket = new List<BasketItem>();

        public Checkout(List<Product> products)
        {
            //could use dependancy injection here instead to allow for data stored in SQL 
            Products = products;
        }

        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string SKU)
        {
            var productFound = Products.FirstOrDefault(p => p.SKU == SKU);
            if (productFound != null)
            {
                var productInBasket = basket.FirstOrDefault(b => b.SKU == SKU);
                if (productInBasket != null)
                    productInBasket.Quantity += 1;
                else
                    basket.Add(new BasketItem { SKU = SKU, Quantity = 1 });
            } else
            {
                throw new ArgumentException($"Invalid item: {SKU}");
            }
        }
    }
}
