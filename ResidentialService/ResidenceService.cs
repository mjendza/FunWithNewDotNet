using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResidentialService.Contracts;

namespace ResidentialService
{
    public class ResidenceService : IResidenceService
    {
        private readonly IResidenceRepository _repository;

        public ResidenceService(IResidenceRepository repository)
        {
            _repository = repository;
        }
        
        public Task<IList<Residence>> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<List<ResidenceReportByMaxSqFt>> GetResidenceReportByMaxSqFt()
        {
            var data = await GetAll();
            var result = data.GroupBy(x => x.City).Select(x => new ResidenceReportByMaxSqFt(){ City = x.Key, MaxSqFt = x.Max(y => y.SqFt) }).ToList();
            return result;
        }

        public async Task<List<ResidenceReportByMaxBedrooms>> GetResidenceReportByMaxBedrooms()
        {
            var data = await GetAll();
            var result = data.GroupBy(x => x.City).Select(x => new ResidenceReportByMaxBedrooms(){ City = x.Key, MaxBedrooms = x.Max(y => y.Beds) }).ToList();
            return result;
        }



    }
}