using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaggerV2.Models;

/// <summary>
/// Hizmet modeli.
/// Bu model, sistemdeki hizmetleri temsil eder ve MongoDB'de saklanır.
/// </summary>
public class Service
{
    /// <summary>
    /// Hizmetin benzersiz tanımlayıcısı.
    /// MongoDB tarafından otomatik olarak oluşturulur.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    /// <summary>
    /// Hizmetin adı.
    /// </summary>
    [BsonElement("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Hizmetin açıklaması.
    /// </summary>
    [BsonElement("description")]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Hizmetin fiyatı.
    /// </summary>
    [BsonElement("price")]
    public decimal Price { get; set; }

    /// <summary>
    /// Hizmetin süresi (dakika cinsinden).
    /// </summary>
    [BsonElement("duration")]
    public int Duration { get; set; }

    /// <summary>
    /// Hizmetin kategorisi.
    /// </summary>
    [BsonElement("category")]
    public string Category { get; set; } = null!;

    /// <summary>
    /// Hizmetin aktif olup olmadığı.
    /// </summary>
    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Hizmetin oluşturulma tarihi.
    /// </summary>
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
} 