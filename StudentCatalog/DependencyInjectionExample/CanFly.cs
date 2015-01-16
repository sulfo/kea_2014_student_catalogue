using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalog.DependencyInjectionExample
{
    public class CanFly : IFlyBehaviour
    {
        public void Fly()
        {
            Console.WriteLine("Yeaahhh, I am flying! ");
        }
    }
}