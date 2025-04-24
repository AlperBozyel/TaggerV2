using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaggerV2.Models;

/// <summary>
/// Araç tipi modeli.
/// Bu model, sistemdeki araç tiplerini temsil eder ve MongoDB'de saklanır.
/// </summary>
public class VehicleType
{
    /// <summary>
    /// Araç tipinin benzersiz tanımlayıcısı.
    /// MongoDB tarafından otomatik olarak oluşturulur.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    /// <summary>
    /// Araç tipinin adı.
    /// </summary>
    [BsonElement("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Araç tipinin açıklaması.
    /// </summary>
    [BsonElement("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Araç tipinin aktif olup olmadığı.
    /// </summary>
    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Araç tipinin oluşturulma tarihi.
    /// </summary>
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
} 