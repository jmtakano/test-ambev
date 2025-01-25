namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct
{
    public class ListProductResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
