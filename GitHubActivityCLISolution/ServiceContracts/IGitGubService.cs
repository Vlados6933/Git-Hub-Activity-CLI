
namespace ServiceContracts
{
    public interface IGitGubService
    {
        Task<List<Dictionary<string, object>>?> FetchActivity(string userName);
    }
}
