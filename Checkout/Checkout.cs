using Checkout.Classes;
using Checkout.Interfaces;

namespace Checkout
{
    public class Checkout : ICheckout
    {
        public List<Product> products { get; }
        List<BasketItem> basket = new List<BasketItem>();

        public Checkout(List<Product> products)
        {
            //could use dependancy injection here instead to allow for data stored in SQL 
            this.products = products;
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach(var basketItem in basket)
            {
                totalPrice += basketItem.BasketItemTotal();
            }

            return totalPrice;
        }

        public void Scan(string SKU)
        {
            var productFound = products.FirstOrDefault(p => p.SKU == SKU);
            if (productFound != null)
            {
                var productInBasket = basket.FirstOrDefault(b => b.Product.SKU == SKU);
                if (productInBasket != null)
                    productInBasket.Quantity += 1;
                else
                    basket.Add(new BasketItem { Product = productFound, Quantity = 1 });
            } else
            {
                throw new ArgumentException($"Invalid item: {SKU}");
            }
        }
    }
}
