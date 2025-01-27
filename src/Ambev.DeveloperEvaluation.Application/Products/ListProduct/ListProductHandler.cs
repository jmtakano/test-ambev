using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct
{
    public class ListProductHandler : IRequestHandler<ListProductCommand, IEnumerable<ListProductResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ListProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListProductResult>> Handle(ListProductCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.ListProductsAsync(request.PageIndex, request.PageSize);

            return _mapper.Map<IEnumerable<ListProductResult>>(products);
        }
    }
}
