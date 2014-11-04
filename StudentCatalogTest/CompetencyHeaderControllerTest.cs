using System;
using System.Collections.Generic;
using System.Web.WebPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudentCatalog.Abstract;
using StudentCatalog.Controllers;
using StudentCatalog.Models;

namespace StudentCatalogTest
{
    [TestClass]
    public class CompetencyControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            var competencyRepositoryMock =
                new Mock<ICompetencyRepository>();

            var competencyHeaderRepositoryMock =
                new Mock<ICompetencyHeaderRepository>();

            CompetenciesController controller =
                new CompetenciesController(
                    competencyHeaderRepositoryMock.Object, 
                    competencyRepositoryMock.Object);

            Competency comp = new Competency
            {
                CompetencyId = 0,
                Name = "My new Competency",
                CompetencyHeaderId = 1
            };

            //act
            controller.Create(comp);

            //assert
            competencyRepositoryMock.Verify( x => x.InsertOrUpdate(comp));
            competencyRepositoryMock.Verify(x => x.Save());
        }




    }
}
