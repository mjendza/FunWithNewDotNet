using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResidentialService.AcceptanceTests
{
    [TestClass]
    public class ResidenceServiceTests
    {
        [TestMethod]
        public async Task ResidenceService_Success()
        {
            //GIVEN
            var sut = new ResidenceCsvRepository("http://net-poland-interview-stretto.us-east-2.elasticbeanstalk.com/api/flats/csv");
            //WHEN
            var data = await sut.GetAll();
            //THEN
            Assert.AreEqual(985, data.Count);
        }

        [TestMethod]
        public async Task GroupByCityTakeMaxSqFt()
        {
            //GIVEN
            var sut = new ResidenceCsvRepository("http://net-poland-interview-stretto.us-east-2.elasticbeanstalk.com/api/flats/csv");
            //WHEN
            var data = await sut.GetAll();
            var result = data.GroupBy(x => x.City).Select(x => new { City = x.Key, MaxSqFt = x.Max(y => y.SqFt) }).ToList();
            //THEN
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public async Task MaxRoomsAndCheapest()
        {
            //GIVEN
            var sut = new ResidenceCsvRepository("http://net-poland-interview-stretto.us-east-2.elasticbeanstalk.com/api/flats/csv");
            //WHEN
            var data = await sut.GetAll();
            var result = data.OrderByDescending(x => x.Rooms).ThenByDescending(x => x.Price).FirstOrDefault();
            //THEN
            Assert.IsNotNull(result);
        }

    }
}