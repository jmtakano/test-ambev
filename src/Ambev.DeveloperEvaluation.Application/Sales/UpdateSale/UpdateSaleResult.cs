using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleResult
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; }
        public DateTimeOffset Date { get; set; }
        public Guid CustomerId { get; set; }
        public User Customer { get; set; }
        public string Branch { get; set; }
        public ICollection<SaleItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
