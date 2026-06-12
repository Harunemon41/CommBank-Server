using CommBank.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CommBank.Services
{
    public class GoalsService
    {
        private readonly IMongoCollection<Goal> _goalsCollection;

        public GoalsService(IOptions<CommBankDatabaseSettings> commBankDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                commBankDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                commBankDatabaseSettings.Value.DatabaseName);

            _goalsCollection = mongoDatabase.GetCollection<Goal>(
                commBankDatabaseSettings.Value.GoalsCollectionName);
        }

        public async Task<List<Goal>> GetAsync() =>
            await _goalsCollection.Find(_ => true).ToListAsync();

        public async Task<Goal?> GetAsync(string id) =>
            await _goalsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Goal newGoal) =>
            await _goalsCollection.InsertOneAsync(newGoal);

        public async Task UpdateAsync(string id, Goal updatedGoal) =>
            await _goalsCollection.ReplaceOneAsync(x => x.Id == id, updatedGoal);

        public async Task RemoveAsync(string id) =>
            await _goalsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
