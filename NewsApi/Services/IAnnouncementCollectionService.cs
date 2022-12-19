using NewsApi.Model;

namespace NewsApi.Services
{
    public interface IAnnouncementCollectionService : ICollectionService<Announcement>
    {
        public Task<List<Announcement>> GetAnnouncementsByCategoryId(string CategoryId);
    }
}
