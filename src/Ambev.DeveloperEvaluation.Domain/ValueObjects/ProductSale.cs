using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    public class ProductSale
    {
        public Guid ProductId { get; }
        public int Quantity { get; }
    }
}
