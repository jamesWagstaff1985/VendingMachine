using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.MachineManager;

namespace VendingMachine.ProductManager
{
    class RemoveProduct
    {
        public static void RemoveProductFromSystem(string product, MachineContents machineContents)
        {
            if(machineContents.ProductsInMachine.Any(p => p.ProductName == product && p.ProductQuantity > 1))
            {
                machineContents.ProductsInMachine
                .Where(p => p.ProductName == product && p.ProductQuantity > 1)
                .Select(p => p.ProductQuantity--)
                .ToList();
            }
            else
            {
                machineContents.ProductsInMachine.RemoveAll(p => p.ProductName == product);
            }
        }
    }
}
