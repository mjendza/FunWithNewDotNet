using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ResidentialService.Contracts;

namespace ResidentialService.UnitTests
{
    [TestClass]
    public class ResidenceServiceTests
    {
        [TestMethod]
        public async Task Check_GetResidenceReportByMaxSqFt_Basic()
        {
            //GIVEN
            var csvRepositoryMock = new Mock<IResidenceRepository>();
            var data = new List<Residence>()
            {
                new() {City = "Test1", SqFt = 19}, new() {City = "Test1", SqFt = 200}
            };
            csvRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(data);
            var sut = new ResidentialService.ResidenceService(csvRepositoryMock.Object);

            //WHEN
            var result = await sut.GetResidenceReportByMaxSqFt();

            //THEN
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(200, result.First().MaxSqFt);
        }

        [TestMethod]
        public async Task Check_GetResidenceReportByMaxSqFt_Advances()
        {
            //GIVEN
            var csvRepositoryMock = new Mock<IResidenceRepository>();
            var data = new List<Residence>()
            {
                new() {City = "Test1", SqFt = 19}, new() {City = "Test1", SqFt = 200},
                new() {City = "Test2", SqFt = 1}, new() {City = "Test2", SqFt = 2}
            };
            csvRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(data);
            var sut = new ResidentialService.ResidenceService(csvRepositoryMock.Object);

            //WHEN
            var result = await sut.GetResidenceReportByMaxSqFt();

            //THEN
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(200, result.First().MaxSqFt);
            Assert.AreEqual(2, result[1].MaxSqFt);
        }
    }
}