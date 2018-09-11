using NUnit.Framework;
using SpecflowIntro.AmazonECommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecflowIntro.DataClass
{
   public class AddCart
    {
     private readonly CartAdd addcart = new CartAdd();

            public string AddItemToCart(string item)
            {
            var x = addcart.ToString();
                return x;
            }

    }
}
