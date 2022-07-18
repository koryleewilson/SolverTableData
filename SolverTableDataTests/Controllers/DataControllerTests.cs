using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using SolverTableData.Controllers;
using SolverTableData.Services.Interfaces;

namespace SolverTableDataTests.Controllers
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetTableDataSucceeds()
        {
            // Arrange
            var mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "001")]).Returns("mock value");
            
            var mockTableService = new Mock<ITableService>(MockBehavior.Strict);
            mockTableService.Setup(x => x.GetTableData("001", "Table")).Returns("JsonTableData");
            
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(a => a.GetSection(It.Is<string>(s => s == "ConnectionStrings"))).Returns(mockConfSection.Object);

            DataController dataController = new DataController(mockConfiguration.Object, mockTableService.Object);
            
            // act
            var result = dataController.GetTableData("001", "Table", null, null) as OkObjectResult;

            // assert
            Assert.That(result.Value, Is.EqualTo("JsonTableData"));
        }
    }
}