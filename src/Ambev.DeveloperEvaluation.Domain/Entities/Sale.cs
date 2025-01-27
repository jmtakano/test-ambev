using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public string SaleNumber { get; set; } 
        public DateTimeOffset Date { get; set; } 
        public Guid CustomerId { get; set; } 
        public string Branch { get; set; } 
        public decimal TotalAmount { get; set; } 
        public bool IsCancelled { get; set; }

        public virtual List<SaleItem> SalesItems { get; set; }
        public virtual User Customer { get; set; }
        public List<DomainEvent> Events { get; private set; } = new List<DomainEvent>();

        public void CalculatePrice()
        {
            TotalAmount = SalesItems.Sum(item =>
            {
                var amount = item.Quantity * item.UnitPrice;
                var discount = CalculateDiscount(item.Quantity, amount);

                item.Discount = discount; 
                return amount - discount; 
            });
        }

        private decimal CalculateDiscount(int quantity, decimal amount)
        {
            if (quantity >= 4 && quantity < 10)
            {
                return amount * 0.10m; 
            }

            if (quantity >= 10 && quantity <= 20)
            {
                return amount * 0.20m; 
            }

            return 0m; 
        }

        public void UpdateSale(string branch, List<SaleItem> salesItems)
        {
            Branch = branch;
            SalesItems = salesItems; 
        }

        public void SaleCancelled(bool saleCancelled)
        {
            IsCancelled = saleCancelled;
        }

        public void MarkAsCreated()
        {
            Events.Add(new SaleCreatedEvent(Id, SaleNumber, TotalAmount));
        }

        public void MarkAsModified()
        {
            Events.Add(new SaleModifiedEvent(Id, SaleNumber, TotalAmount));
        }
    }
}
