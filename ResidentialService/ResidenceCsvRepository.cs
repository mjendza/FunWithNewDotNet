using System.Collections.Generic;
using System.Threading.Tasks;
using ResidentialService.Contracts;

namespace ResidentialService
{
    public class ResidenceCsvRepository : IResidenceRepository
    { 
        private readonly string _endpoint;
        
        public ResidenceCsvRepository(string endpoint)
        {
            _endpoint = endpoint;
        }
        public Task<IList<Residence>> GetAll()
        {
            return Helpers.CsvHelper.ReadRecordsFromUri<Residence>(_endpoint);
        }
    }
}