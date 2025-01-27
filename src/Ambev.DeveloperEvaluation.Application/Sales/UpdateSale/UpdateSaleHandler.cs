using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper; 
        
        public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
        {
            List<SaleItem> saleItems = new List<SaleItem>();
            var validator = new UpdateSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(command.Id);

            if (sale is null)
                throw new InvalidOperationException($"Sale not found in the system.");

            foreach (var item in command.Items)
            {
                var saleItem = new SaleItem();
                var product = await _saleRepository.GetSaleProduct(item.ProductId);

                if (product is null)
                    throw new InvalidOperationException($"Product id {item.ProductId} not found in the system.");

                saleItem.ProductId = item.ProductId;
                saleItem.UnitPrice = product.Price;
                saleItem.Quantity = item.Quantity;

                saleItems.Add(saleItem);
            }

            sale.UpdateSale(command.Branch, saleItems);
            sale.CalculatePrice();
            sale.MarkAsModified();

            var createdSale = await _saleRepository.UpdateAsync(sale, cancellationToken);
            var result = _mapper.Map<UpdateSaleResult>(createdSale);

            return null;
        }
    }
}
