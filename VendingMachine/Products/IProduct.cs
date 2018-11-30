using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.ProductManager
{
    interface IProduct
    {
        int ProductPriceInCents { get; set; }
        int ProductQuantity { get; set; }
        string ProductName { get; set; }
    }
}
