using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public string SaleNumber { get; set; } 
        public Guid CustomerId { get; set; } 
        public string Branch { get; set; } 
        public ICollection<CreateSaleItemRequest> Items { get; set; } 
    }
}
