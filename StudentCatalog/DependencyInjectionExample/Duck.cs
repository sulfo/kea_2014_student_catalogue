using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalog.DependencyInjectionExample
{
    public abstract class Duck
    {
        public IFlyBehaviour FlyBehaviour { get; set; }

        protected Duck(IFlyBehaviour flyBehaviour)
        {
            this.FlyBehaviour = flyBehaviour;
        }

        public void Fly()
        {
            FlyBehaviour.Fly();
        }

        public void Quack()
        {
            Console.WriteLine("Quack!");
        }

        public abstract void Display();
    }
}