using Homakers.Domain.DataModels;
namespace Homakers.Applications.RepoInterfaces
{
    public interface IUtilityRepository
    {
        public Task<List<Districts>> GetDistrictsAsync();
    }
}
