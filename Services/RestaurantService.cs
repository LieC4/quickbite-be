using Microsoft.EntityFrameworkCore;
using QuickBiteBE.Controllers;
using QuickBiteBE.Data;
using QuickBiteBE.Models;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class RestaurantService : IRestaurantService
{
    private QuickBiteContext _context { get; set; }

    public RestaurantService(QuickBiteContext context)
    {
        _context = context;
    }

    public async Task<List<Restaurant>> GetAllRestaurants()
        => await QueryAllRestaurants().ToListAsync();

    public Task<Restaurant> GetRestaurantById(int id)
        => _context.Restaurants.FirstAsync(restaurant => restaurant.Id == id);

    public async Task<List<Restaurant>> FilterRestaurantsBySearchBar(string input)
    {
        var restaurants =
            (from restaurant in await QueryAllRestaurants().ToListAsync()
                from dish in restaurant.Dishes
                where dish.Name == input
                select restaurant)
            .ToList();
        return restaurants;
    }

    private IQueryable<Restaurant> QueryAllRestaurants()
        => _context.Restaurants;

    public async Task<Restaurant> CreateRestaurant(AddRestaurantRequest request)
    {
        var restaurant = new Restaurant
        {
            Name = request.Name,
            Description = request.Description,
            Location = request.Location,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            MainPictureUrl = request.MainPictureUrl,
            DeliveryCost = request.DeliveryCost,
            Dishes = new List<Dish>()
        };
        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();
        return restaurant;
    }
}