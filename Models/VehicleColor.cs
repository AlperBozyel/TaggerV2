using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaggerV2.Models;

/// <summary>
/// Araç rengi modeli.
/// Bu model, sistemdeki araç renklerini temsil eder ve MongoDB'de saklanır.
/// </summary>
public class VehicleColor
{
    /// <summary>
    /// Araç renginin benzersiz tanımlayıcısı.
    /// MongoDB tarafından otomatik olarak oluşturulur.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    /// <summary>
    /// Araç renginin adı.
    /// </summary>
    [BsonElement("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Araç renginin hex kodu.
    /// </summary>
    [BsonElement("hexCode")]
    public string? HexCode { get; set; }

    /// <summary>
    /// Araç renginin aktif olup olmadığı.
    /// </summary>
    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Araç renginin oluşturulma tarihi.
    /// </summary>
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
} 