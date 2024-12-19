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
                var product = products.First(p => p.SKU == basketItem.SKU);
                if(product == null)
                {
                    throw new Exception($"Product not found with SKU {basketItem.SKU}");
                }

                if(product.Discount != null)
                {
                    int totalDiscountGroups = basketItem.Quantity / product.Discount.Quantity;
                    int remainingUndiscountedItems = basketItem.Quantity % product.Discount.Quantity;

                    totalPrice += (totalDiscountGroups * product.Discount.DiscountPrice);
                    totalPrice += (remainingUndiscountedItems * product.Price);

                } else
                {
                    totalPrice += (basketItem.Quantity * product.Price);
                }                
            }

            return totalPrice;
        }

        public void Scan(string SKU)
        {
            var productFound = products.FirstOrDefault(p => p.SKU == SKU);
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
