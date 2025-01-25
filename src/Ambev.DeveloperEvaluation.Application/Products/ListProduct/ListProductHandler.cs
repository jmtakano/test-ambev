using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct
{
    public class ListProductHandler : IRequestHandler<ListProductCommand, ListProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public async Task<ListProductResult> Handle(ListProductCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.ListProductsAsync(request.PageIndex, request.PageSize);

            return _mapper.Map<ListProductResult>(products);
        }
    }
}
