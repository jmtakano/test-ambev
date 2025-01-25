using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingProduct = await _productRepository.GetByNameAsync(command.Title, cancellationToken);
            if (existingProduct != null)
                throw new InvalidOperationException($"Product with title name {command.Title} already exists");

            var product = _mapper.Map<Product>(command);

            var updatedProduct = await _productRepository.UpdateAsync(product, cancellationToken);
            var result = _mapper.Map<UpdateProductResult>(updatedProduct);
            return result;
        }
    }
}
