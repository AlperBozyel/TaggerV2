using Microsoft.AspNetCore.Mvc;
using TaggerV2.Models;
using TaggerV2.Services;

namespace TaggerV2.Controllers;

/// <summary>
/// Kullanıcı işlemlerini yöneten API Controller.
/// Bu controller, kullanıcıların CRUD (Create, Read, Update, Delete) operasyonlarını sağlar.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly MongoDBService _mongoDBService;

    /// <summary>
    /// UserController sınıfının yapıcı metodu.
    /// MongoDB servisini dependency injection ile alır.
    /// </summary>
    /// <param name="mongoDBService">MongoDB servis nesnesi</param>
    public UserController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    /// <summary>
    /// Tüm kullanıcıları getirir.
    /// </summary>
    /// <returns>Kullanıcı listesi</returns>
    [HttpGet]
    public async Task<List<User>> Get() =>
        await _mongoDBService.GetUsersAsync();

    /// <summary>
    /// Belirli bir ID'ye sahip kullanıcıyı getirir.
    /// </summary>
    /// <param name="id">24 karakterlik MongoDB ObjectId</param>
    /// <returns>Kullanıcı nesnesi veya 404 Not Found</returns>
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await _mongoDBService.GetUserAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    /// <summary>
    /// Yeni bir kullanıcı oluşturur.
    /// </summary>
    /// <param name="newUser">Oluşturulacak kullanıcı nesnesi</param>
    /// <returns>201 Created ve oluşturulan kullanıcı</returns>
    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        await _mongoDBService.CreateUserAsync(newUser);

        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }

    /// <summary>
    /// Mevcut bir kullanıcıyı günceller.
    /// </summary>
    /// <param name="id">24 karakterlik MongoDB ObjectId</param>
    /// <param name="updatedUser">Güncellenmiş kullanıcı nesnesi</param>
    /// <returns>204 No Content veya 404 Not Found</returns>
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, User updatedUser)
    {
        var user = await _mongoDBService.GetUserAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        updatedUser.Id = id;

        await _mongoDBService.UpdateUserAsync(id, updatedUser);

        return NoContent();
    }

    /// <summary>
    /// Bir kullanıcıyı siler.
    /// </summary>
    /// <param name="id">24 karakterlik MongoDB ObjectId</param>
    /// <returns>204 No Content veya 404 Not Found</returns>
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _mongoDBService.GetUserAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        await _mongoDBService.RemoveUserAsync(id);

        return NoContent();
    }
} 