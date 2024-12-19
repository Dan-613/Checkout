using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Classes
{
    internal class BasketItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public int BasketItemTotal()
        {
            int total = 0;

            if (this.Product.Discount != null)
            {
                int totalDiscountGroups = this.Quantity / this.Product.Discount.Quantity;
                int remainingUndiscountedItems = this.Quantity % this.Product.Discount.Quantity;

                total += (totalDiscountGroups * this.Product.Discount.DiscountPrice);
                total += (remainingUndiscountedItems * this.Product.Price);
            }
            else
            {
                total += (this.Quantity * this.Product.Price);
            }

            return total;
        }
    }
}
