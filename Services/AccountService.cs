using ASP_Web_Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ASP_Web_Api.Services
{
    public class AccountService
    {
        private readonly IMongoCollection<Account> _accountCollection;

        public AccountService(
            IOptions<DbSetting> dbSetting)
        {
            var mongoClient = new MongoClient(
                dbSetting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                dbSetting.Value.DatabaseName);

            _accountCollection = mongoDatabase.GetCollection<Account>(
                dbSetting.Value.AccountCollection);
        }

        public async Task<List<Account>> GetAsync() =>
            await _accountCollection.Find(_ => true).ToListAsync();

        public async Task<List<Account>> GetAsync(string username) =>
            await _accountCollection.Find(account => account.username == username).ToListAsync();

        public async Task CreateAsync(Account account) =>
            await _accountCollection.InsertOneAsync(account);

        public async Task UpdateAsync(Account accountUpdate) =>
            await _accountCollection.ReplaceOneAsync(account => account.username == accountUpdate.username, accountUpdate);

        public async Task DeleteAsync(string username) =>
            await _accountCollection.DeleteOneAsync(account => account.username == username);
    }
}
