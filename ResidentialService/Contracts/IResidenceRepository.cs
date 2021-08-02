using System.Collections.Generic;
using System.Threading.Tasks;
using ResidentialService.Contracts;

namespace ResidentialService
{
    public interface IResidenceRepository
    {
        Task<IList<Residence>> GetAll();
    }
}