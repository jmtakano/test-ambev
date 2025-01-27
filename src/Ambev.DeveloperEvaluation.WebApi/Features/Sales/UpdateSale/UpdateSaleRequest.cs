using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequest
    {
        public Guid Id { get; set; }
        //public string SaleNumber { get; set; }
        //public Guid CustomerId { get; set; }
        public string Branch { get; set; }
        public ICollection<CreateSaleItemRequest> Items { get; set; }
    }
}
