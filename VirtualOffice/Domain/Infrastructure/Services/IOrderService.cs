using Domain.Models.Orders;

namespace Domain.Infrastructure.Services
{
    public interface IOrderService
    {
        int AddOrder(CartHeader cartModel);
    }
}