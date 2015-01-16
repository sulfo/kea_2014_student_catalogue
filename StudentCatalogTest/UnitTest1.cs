using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentCatalog.DependencyInjectionExample;

namespace StudentCatalogTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            CanFly canFly = new CanFly();
            CannotFly cannotFly = new CannotFly();

            MallardDuck mallardDuck = 
                new MallardDuck(canFly);

            RubberDuck rubberDuck = 
                new RubberDuck(cannotFly);

            //Act
            mallardDuck.Display();
            mallardDuck.Fly();

            rubberDuck.Display();
            rubberDuck.Fly();
            

            //Assert
        }
    }
}
