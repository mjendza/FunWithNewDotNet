using System.Collections.Generic;
using System.Threading.Tasks;
using ResidentialService.Contracts;

namespace ResidentialService
{
    public interface IResidenceService
    {
        Task<IList<Residence>> GetAll();
    }
}