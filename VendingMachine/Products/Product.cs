using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.ProductManager
{
    class Product : IProduct
    {
        public string ProductName { get; set; }
        public int ProductPriceInCents { get; set; }
        public int ProductQuantity { get; set; }

        public Product(string productName, int productPriceInCents, int productQuantity)
        {
            ProductName = productName;
            ProductPriceInCents = productPriceInCents;
            ProductQuantity = productQuantity;
        }
    }
}
