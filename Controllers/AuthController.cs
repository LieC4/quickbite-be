using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Data;
using QuickBiteBE.Dtos;
using QuickBiteBE.Helpers;
using QuickBiteBE.Models;

namespace QuickBiteBE.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private IUserRepository _repository;
    private IJWTService _jwtService;

    public AuthController(IUserRepository repository, IJWTService jwtService)
    {
        _repository = repository;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDto dto)
    {
        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Cart = new Cart(),
            Orders = new List<Order>()
        };
        return Created("success", _repository.Create(user));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        var user = _repository.GetByEmail(dto.Email);
        if (user == null)
        {
            return BadRequest(new { message = "Invalid Credentials" });
        }

        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
        {
            return BadRequest(new { message = "Invalid Credentials" });
        }

        var jwt = _jwtService.Generate(user.Id);
        Response.Cookies.Append("jwt", jwt, new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Lax

        });
        return Ok(new
        {
            message = "success",
            jwt = jwt
        });
    }

    [HttpGet("user")]
    public IActionResult User()
    {
        try
        {
            var jwt = Request.Cookies["jwt"];

            var token = _jwtService.Verify(jwt);
            var userId = int.Parse(token.Issuer);
            var user = _repository.GetById(userId);
            return Ok(user);
        }
        catch (Exception _)
        {
            return Unauthorized();
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");

        return Ok(new
        {
            message = "success"
        });
    }
}