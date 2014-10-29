using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalog.DependencyInjectionExample
{
    public class CannotFly : IFlyBehaviour 
    {
        public void Fly()
        {
            Console.WriteLine("(*sob*) I can't fly!");
        }
    }
}