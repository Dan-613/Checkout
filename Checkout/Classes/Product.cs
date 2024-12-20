﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Classes
{
    public class Product
    {        
        public string SKU { get; set; } //depending on the volume of data and size of a basket, this could store a reference to the actual product, rather than the SKU code
        public int Price { get; set; }
        public ProductDiscount? Discount { get; set; }
    }

    public class ProductDiscount
    {
        public int Quantity { get; set; }
        public int DiscountPrice { get; set; }
    }

}
