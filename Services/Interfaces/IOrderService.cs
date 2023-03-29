using QuickBiteBE.Models;

namespace QuickBiteBE.Services.Interfaces;

public interface IOrderService
{
    Task<Order> PlaceOrder(int userId, string address);
    Task<List<Order>> QueryAllOrdersByUserId(int userId);
}