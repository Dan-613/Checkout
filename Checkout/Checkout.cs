using Checkout.Classes;
using Checkout.Interfaces;

namespace Checkout
{
    public class Checkout : ICheckout
    {
        public List<Product> Products { get; }

        public Checkout(List<Product> products)
        {
            Products = products;
        }

        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
}
