
namespace CheckoutTests
{
    public class ScanTests
    {
        [Fact]
        public void ScanTest1_OneItem()
        {
            var checkout = new Checkout.Checkout();

            checkout.Scan("A");
            Assert.True(checkout.GetTotalPrice() == 50,"Single Item Scan failed - total price should have been 50");

        }

        [Fact]
        public void ScanTest2_MultipleSingleItems()
        {
            var checkout = new Checkout.Checkout();

            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            Assert.True(checkout.GetTotalPrice() == 100, "Multiple Single Items Scan failed - total price should have been 100");

        }

        [Fact]
        public void ScanTest3_MultipleIdenticalItems_NoSpecials()
        {
            var checkout = new Checkout.Checkout();

            checkout.Scan("C");
            checkout.Scan("C");
            checkout.Scan("C");

            Assert.True(checkout.GetTotalPrice() == 60, "Multiple Identical Items Scan failed - total price should have been 60");

        }

        [Fact]
        public void ScanTest4_MultipleIdenticalItems_SpecialsOnly()
        {
            var checkout = new Checkout.Checkout();

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.True(checkout.GetTotalPrice() == 130, "Multiple Identical Items Specials Only Scan failed - total price should have been 130");

        }

        [Fact]
        public void ScanTest5_SpecialsAndPartSpecials()
        {
            var checkout = new Checkout.Checkout();

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            //and one single item which is an incomplete special
            checkout.Scan("A");           

            Assert.True(checkout.GetTotalPrice() == 180, "Specials and Incomplete Specials Scan failed - total price should have been 180");

        }

        [Fact]
        public void ScanTest6_NormalItemsAndSpecials()
        {
            var checkout = new Checkout.Checkout();

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            //and one different item
            checkout.Scan("B");

            Assert.True(checkout.GetTotalPrice() == 160, "Specials and Normal Item Scan failed - total price should have been 160");

        }

        [Fact]
        public void ScanTest7_FullBasket()
        {
            var checkout = new Checkout.Checkout();

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            
            checkout.Scan("B");

            checkout.Scan("C");
            checkout.Scan("C");

            checkout.Scan("D");

            Assert.True(checkout.GetTotalPrice() == 215, "Full Basket Scan failed - total price should have been 215");

        }

        [Fact]
        public void ScanTest8_TestInvalidSelection()
        {
            var checkout = new Checkout.Checkout();

            var exception = Assert.Throws <ArgumentException>(() => checkout.Scan("E"));

            Assert.Equal("Invalid item: E", exception.Message);

        }

    }
}