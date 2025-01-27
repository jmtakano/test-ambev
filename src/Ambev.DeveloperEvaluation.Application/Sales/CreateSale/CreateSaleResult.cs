using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleResult
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
