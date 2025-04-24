using Microsoft.AspNetCore.Mvc;
using TaggerV2.Models;
using TaggerV2.Services;

namespace TaggerV2.Controllers;

/// <summary>
/// Sürücü işlemlerini yöneten API Controller.
/// Bu controller, sürücülerin CRUD (Create, Read, Update, Delete) operasyonlarını sağlar.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class DriverController : ControllerBase
{
    private readonly MongoDBService _mongoDBService;

    /// <summary>
    /// DriverController sınıfının yapıcı metodu.
    /// MongoDB servisini dependency injection ile alır.
    /// </summary>
    /// <param name="mongoDBService">MongoDB servis nesnesi</param>
    public DriverController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    /// <summary>
    /// Tüm sürücüleri getirir.
    /// </summary>
    /// <returns>Sürücü listesi</returns>
    [HttpGet]
    public async Task<List<Driver>> Get() =>
        await _mongoDBService.GetDriversAsync();

    /// <summary>
    /// Belirli bir ID'ye sahip sürücüyü getirir.
    /// </summary>
    /// <param name="id">24 karakterlik MongoDB ObjectId</param>
    /// <returns>Sürücü nesnesi veya 404 Not Found</returns>
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Driver>> Get(string id)
    {
        var driver = await _mongoDBService.GetDriverAsync(id);

        if (driver is null)
        {
            return NotFound();
        }

        return driver;
    }

    /// <summary>
    /// Yeni bir sürücü oluşturur.
    /// </summary>
    /// <param name="newDriver">Oluşturulacak sürücü nesnesi</param>
    /// <returns>201 Created ve oluşturulan sürücü</returns>
    [HttpPost]
    public async Task<IActionResult> Post(Driver newDriver)
    {
        await _mongoDBService.CreateDriverAsync(newDriver);

        return CreatedAtAction(nameof(Get), new { id = newDriver.Id }, newDriver);
    }

    /// <summary>
    /// Mevcut bir sürücüyü günceller.
    /// </summary>
    /// <param name="id">24 karakterlik MongoDB ObjectId</param>
    /// <param name="updatedDriver">Güncellenmiş sürücü nesnesi</param>
    /// <returns>204 No Content veya 404 Not Found</returns>
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Driver updatedDriver)
    {
        var driver = await _mongoDBService.GetDriverAsync(id);

        if (driver is null)
        {
            return NotFound();
        }

        updatedDriver.Id = id;

        await _mongoDBService.UpdateDriverAsync(id, updatedDriver);

        return NoContent();
    }

    /// <summary>
    /// Bir sürücüyü siler.
    /// </summary>
    /// <param name="id">24 karakterlik MongoDB ObjectId</param>
    /// <returns>204 No Content veya 404 Not Found</returns>
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var driver = await _mongoDBService.GetDriverAsync(id);

        if (driver is null)
        {
            return NotFound();
        }

        await _mongoDBService.RemoveDriverAsync(id);

        return NoContent();
    }
} 