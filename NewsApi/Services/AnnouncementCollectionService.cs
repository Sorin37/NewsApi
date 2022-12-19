using MongoDB.Driver;
using NewsApi.Model;
using NewsApi.Settings;
using System.Reflection;

namespace NewsApi.Services
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {
        private IMongoCollection<Announcement> _announcements;
        public AnnouncementCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _announcements = database.GetCollection<Announcement>(settings.AnnouncementsCollectionName);
        }


        public async Task<List<Announcement>> GetAll()
        {
            var result = await _announcements.FindAsync(a => true);
            return result.ToList();
        }

        public async Task<Announcement> Get(Guid id)
        {
            return (await _announcements.FindAsync(a => a.Id == id)).FirstOrDefault();
        }

        public async Task<bool> Create(Announcement model)
        {
            if (model.Id == Guid.Empty)
            {
                model.Id = Guid.NewGuid();
            }

            await _announcements.InsertOneAsync(model);
            return true;

        }

        public async Task<bool> Update(Guid id, Announcement model)
        {
            model.Id = id;
            var result = await _announcements.ReplaceOneAsync(a => a.Id == id, model);

            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _announcements.InsertOneAsync(model);
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _announcements.DeleteOneAsync(a => a.Id == id);

            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;

        }

        public async Task<List<Announcement>> GetAnnouncementsByCategoryId(string CategoryId)
        {
            return (await _announcements.FindAsync(a => a.Category == CategoryId)).ToList();
        }

    }
}
