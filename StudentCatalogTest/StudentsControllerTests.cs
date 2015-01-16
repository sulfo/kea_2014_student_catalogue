using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudentCatalog.Abstract;
using StudentCatalog.Controllers;
using StudentCatalog.Models;

namespace StudentCatalogTest
{
    [TestClass]
    public class StudentsControllerTests
    {
        [TestMethod]
        public void CanNotSaveInvalidStudent()
        {
            var mockStudentsRepository = new Mock<IStudentRepository>();
            var mockCompetencyHeaderRepository = new Mock<ICompetencyHeaderRepository>();

            StudentsController controller = new StudentsController(mockStudentsRepository.Object, mockCompetencyHeaderRepository.Object);

            var badModel = new Student { StudentId = 0, Lastname = "Kirschberg", ProfileImagePath = "", Email = "cdhja@faj.dj", MobilePhone = "12345678" }; //empty firstname


            //modelbinder does something like this.
            var validationContext = new ValidationContext(badModel, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(badModel, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            //act
            var result = controller.Create(badModel, null) as ViewResult;


            //check at repositoriet's insert og save metoder blev kaldt
            mockStudentsRepository.Verify(m => m.InsertOrUpdate(badModel), Times.Never());
            mockStudentsRepository.Verify(m => m.Save(), Times.Never());
            Assert.IsNotNull(result);
        }
    }
}
