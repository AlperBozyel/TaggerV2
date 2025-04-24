using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaggerV2.Models;

namespace TaggerV2.Services;

/// <summary>
/// MongoDB veritabanı işlemlerini yöneten servis sınıfı.
/// Bu sınıf, User ve Driver modelleri için CRUD (Create, Read, Update, Delete) operasyonlarını sağlar.
/// </summary>
public class MongoDBService
{
    private readonly IMongoCollection<User> _usersCollection;
    private readonly IMongoCollection<Driver> _driversCollection;

    /// <summary>
    /// MongoDBService sınıfının yapıcı metodu.
    /// appsettings.json'dan MongoDB bağlantı ayarlarını alır ve collection'ları başlatır.
    /// </summary>
    /// <param name="mongoDBSettings">MongoDB bağlantı ayarları</param>
    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        var mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _usersCollection = mongoDatabase.GetCollection<User>(mongoDBSettings.Value.UsersCollectionName);
        _driversCollection = mongoDatabase.GetCollection<Driver>(mongoDBSettings.Value.DriversCollectionName);
    }

    #region User Operations

    /// <summary>
    /// Tüm kullanıcıları getirir.
    /// </summary>
    /// <returns>Kullanıcı listesi</returns>
    public async Task<List<User>> GetUsersAsync() =>
        await _usersCollection.Find(_ => true).ToListAsync();

    /// <summary>
    /// Belirli bir ID'ye sahip kullanıcıyı getirir.
    /// </summary>
    /// <param name="id">Kullanıcı ID'si</param>
    /// <returns>Kullanıcı nesnesi veya null</returns>
    public async Task<User?> GetUserAsync(string id) =>
        await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    /// <summary>
    /// Yeni bir kullanıcı oluşturur.
    /// </summary>
    /// <param name="user">Oluşturulacak kullanıcı nesnesi</param>
    public async Task CreateUserAsync(User user) =>
        await _usersCollection.InsertOneAsync(user);

    /// <summary>
    /// Mevcut bir kullanıcıyı günceller.
    /// </summary>
    /// <param name="id">Güncellenecek kullanıcının ID'si</param>
    /// <param name="user">Güncellenmiş kullanıcı nesnesi</param>
    public async Task UpdateUserAsync(string id, User user) =>
        await _usersCollection.ReplaceOneAsync(x => x.Id == id, user);

    /// <summary>
    /// Bir kullanıcıyı siler.
    /// </summary>
    /// <param name="id">Silinecek kullanıcının ID'si</param>
    public async Task RemoveUserAsync(string id) =>
        await _usersCollection.DeleteOneAsync(x => x.Id == id);

    #endregion

    #region Driver Operations

    /// <summary>
    /// Tüm sürücüleri getirir.
    /// </summary>
    /// <returns>Sürücü listesi</returns>
    public async Task<List<Driver>> GetDriversAsync() =>
        await _driversCollection.Find(_ => true).ToListAsync();

    /// <summary>
    /// Belirli bir ID'ye sahip sürücüyü getirir.
    /// </summary>
    /// <param name="id">Sürücü ID'si</param>
    /// <returns>Sürücü nesnesi veya null</returns>
    public async Task<Driver?> GetDriverAsync(string id) =>
        await _driversCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    /// <summary>
    /// Yeni bir sürücü oluşturur.
    /// </summary>
    /// <param name="driver">Oluşturulacak sürücü nesnesi</param>
    public async Task CreateDriverAsync(Driver driver) =>
        await _driversCollection.InsertOneAsync(driver);

    /// <summary>
    /// Mevcut bir sürücüyü günceller.
    /// </summary>
    /// <param name="id">Güncellenecek sürücünün ID'si</param>
    /// <param name="driver">Güncellenmiş sürücü nesnesi</param>
    public async Task UpdateDriverAsync(string id, Driver driver) =>
        await _driversCollection.ReplaceOneAsync(x => x.Id == id, driver);

    /// <summary>
    /// Bir sürücüyü siler.
    /// </summary>
    /// <param name="id">Silinecek sürücünün ID'si</param>
    public async Task RemoveDriverAsync(string id) =>
        await _driversCollection.DeleteOneAsync(x => x.Id == id);

    #endregion
} 