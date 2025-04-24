using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaggerV2.Models;

/// <summary>
/// Araç modeli.
/// Bu model, sistemdeki araçları temsil eder ve MongoDB'de saklanır.
/// </summary>
public class Vehicle
{
    /// <summary>
    /// Aracın benzersiz tanımlayıcısı.
    /// MongoDB tarafından otomatik olarak oluşturulur.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    /// <summary>
    /// Aracın plaka numarası.
    /// </summary>
    [BsonElement("plateNumber")]
    public string PlateNumber { get; set; } = null!;

    /// <summary>
    /// Aracın markası.
    /// </summary>
    [BsonElement("brand")]
    public string Brand { get; set; } = null!;

    /// <summary>
    /// Aracın modeli.
    /// </summary>
    [BsonElement("model")]
    public string Model { get; set; } = null!;

    /// <summary>
    /// Aracın üretim yılı.
    /// </summary>
    [BsonElement("year")]
    public int Year { get; set; }

    /// <summary>
    /// Aracın renk referansı.
    /// VehicleColor koleksiyonundaki bir belgeye referans verir.
    /// </summary>
    [BsonElement("colorId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ColorId { get; set; } = null!;

    /// <summary>
    /// Aracın tip referansı.
    /// VehicleType koleksiyonundaki bir belgeye referans verir.
    /// </summary>
    [BsonElement("typeId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string TypeId { get; set; } = null!;

    /// <summary>
    /// Aracın aktif olup olmadığı.
    /// </summary>
    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Aracın oluşturulma tarihi.
    /// </summary>
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Aracın renk bilgisi.
    /// MongoDB'de saklanmaz, sadece uygulama tarafında kullanılır.
    /// </summary>
    [BsonIgnore]
    public VehicleColor? Color { get; set; }

    /// <summary>
    /// Aracın tip bilgisi.
    /// MongoDB'de saklanmaz, sadece uygulama tarafında kullanılır.
    /// </summary>
    [BsonIgnore]
    public VehicleType? Type { get; set; }
}

/*
 * Navigation Property'ler Hakkında:
 * 
 * Vehicle sınıfında bulunan Color ve Type navigation property'leri, MongoDB'de saklanmayan
 * ancak uygulama içinde ilişkili verilere kolay erişim sağlayan özelliklerdir.
 * 
 * Bu property'ler, ColorId ve TypeId foreign key'leri üzerinden VehicleColor ve VehicleType
 * koleksiyonlarındaki ilgili belgelere referans verir. Bu sayede:
 * 
 * - vehicle.Color.Name ile aracın renginin adına
 * - vehicle.Type.Name ile aracın tipinin adına
 * 
 * gibi ilişkili verilere doğrudan erişilebilir.
 * 
 * [BsonIgnore] attribute'u ile işaretlenmiş olmaları, bu property'lerin MongoDB'de
 * saklanmayacağını belirtir. Bunun yerine, uygulama seviyesinde ilişkili verilerin
 * yüklenmesi ve yönetilmesi için kullanılırlar.
 */ 