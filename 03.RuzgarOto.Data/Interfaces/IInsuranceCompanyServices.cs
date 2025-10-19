using _01.RuzgarOto.Entity;
using _04.RuzgarOto.Helper;

namespace _03.RuzgarOto.Data.Interfaces
{
    public interface IInsuranceCompanyServices : IBaseRepository<InsuranceCompany>, IImages
    {
        Task<IEnumerable<InsuranceCompany>> GetOrderedInsuranceCompaniesAsync();
    }
}
