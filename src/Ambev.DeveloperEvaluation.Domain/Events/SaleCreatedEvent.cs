using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleCreatedEvent : DomainEvent
    {
        public Guid SaleId { get; set; }
        public string SaleNumber { get; set; }
        public decimal TotalAmount { get; set; }

        public SaleCreatedEvent(Guid saleId, string saleNumber, decimal totalAmount)
        {
            SaleId = saleId;
            SaleNumber = saleNumber;
            TotalAmount = totalAmount;
        }
    }
}
