using System;
using System.Linq;
using System.Threading.Tasks;
using SomeApplication.Business.DTO;
using SomeApplication.Business.Model;
using SomeApplication.Interfaces.Repository;
using SomeApplication.Interfaces.Services;

namespace SomeApplication.Services.SalesOrders
{
    internal class SalesOrderService : ISalesOrderService
    {
        private readonly IApplicationRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public SalesOrderService(IApplicationRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateSalesOrder(SalesOrderDTO salesOrderDTO)
        {

            await this.unitOfWork.SaveChangesAsync();
        }
    }
}
