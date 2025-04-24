using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaggerV2.Models;

/// <summary>
/// Sürücü modeli.
/// Bu model, sistemdeki sürücüleri temsil eder ve MongoDB'de saklanır.
/// </summary>
public class Driver
{
    /// <summary>
    /// Sürücünün benzersiz tanımlayıcısı.
    /// MongoDB tarafından otomatik olarak oluşturulur.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    /// <summary>
    /// Sürücünün adı.
    /// </summary>
    [BsonElement("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Sürücünün e-posta adresi.
    /// </summary>
    [BsonElement("email")]
    public string Email { get; set; } = null!;

    /// <summary>
    /// Sürücünün telefon numarası.
    /// </summary>
    [BsonElement("phone")]
    public string Phone { get; set; } = null!;

    /// <summary>
    /// Sürücünün ehliyet numarası.
    /// </summary>
    [BsonElement("licenseNumber")]
    public string LicenseNumber { get; set; } = null!;

    /// <summary>
    /// Sürücünün ehliyet sınıfı.
    /// </summary>
    [BsonElement("licenseClass")]
    public string LicenseClass { get; set; } = null!;

    /// <summary>
    /// Sürücünün ehliyet geçerlilik tarihi.
    /// </summary>
    [BsonElement("licenseExpiryDate")]
    public DateTime LicenseExpiryDate { get; set; }

    /// <summary>
    /// Sürücünün oluşturulma tarihi.
    /// </summary>
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// Konum bilgisini temsil eden sınıf.
/// MongoDB GeoJSON Point formatına uygun olarak tasarlanmıştır.
/// </summary>
public class Location
{
    /// <summary>
    /// GeoJSON tipi.
    /// Point tipi için "Point" olmalıdır.
    /// </summary>
    [BsonElement("type")]
    public string Type { get; set; } = "Point";

    /// <summary>
    /// Konum koordinatları.
    /// [boylam, enlem] formatında saklanır.
    /// Örnek: [32.8597, 39.9334] (Ankara koordinatları)
    /// </summary>
    [BsonElement("coordinates")]
    public double[] Coordinates { get; set; } = null!;
} 