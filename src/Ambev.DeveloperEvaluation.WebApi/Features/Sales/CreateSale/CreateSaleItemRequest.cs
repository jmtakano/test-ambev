﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; } 
        //public decimal UnitPrice { get; set; } 
        //public decimal Discount { get; set; } 
        //public decimal TotalAmount { get; set; } 
    }
}
