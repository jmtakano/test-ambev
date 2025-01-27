using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            List<SaleItem> saleItems = new List<SaleItem>();
            var validator = new CreateSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existUser = await _saleRepository.ExistUser(command.CustomerId);

            if (!existUser)
                throw new InvalidOperationException($"Customer not found in the system.");

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

            var sale = _mapper.Map<Sale>(command);
            sale.Date = DateTimeOffset.UtcNow;
            sale.SalesItems = saleItems;

            sale.CalculatePrice();
            sale.MarkAsCreated(); //Event.

            var createdSale= await _saleRepository.CreateAsync(sale, cancellationToken);
            var result = _mapper.Map<CreateSaleResult>(createdSale);

           
            return result;
        }
    }
}
