using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaggerV2.Models;

/// <summary>
/// Kullanıcı modeli.
/// Bu model, sistemdeki kullanıcıları temsil eder ve MongoDB'de saklanır.
/// </summary>
public class User
{
    /// <summary>
    /// Kullanıcının benzersiz tanımlayıcısı.
    /// MongoDB tarafından otomatik olarak oluşturulur.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    /// <summary>
    /// Kullanıcının adı.
    /// </summary>
    [BsonElement("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Kullanıcının e-posta adresi.
    /// </summary>
    [BsonElement("email")]
    public string Email { get; set; } = null!;

    /// <summary>
    /// Kullanıcının telefon numarası.
    /// </summary>
    [BsonElement("phone")]
    public string Phone { get; set; } = null!;

    /// <summary>
    /// Kullanıcının oluşturulma tarihi.
    /// </summary>
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Kullanıcının aktif olup olmadığını belirten bayrak.
    /// Varsayılan olarak true'dur.
    /// </summary>
    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;
} 