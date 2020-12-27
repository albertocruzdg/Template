using System;
using System.Threading.Tasks;
using SomeApplication.Business.DTO;

namespace SomeApplication.Interfaces.Services
{
    public interface IPriceService
    {
        Task ChangePrice(Guid productId, MoneyAmountDTO newPrice);
    }
}
