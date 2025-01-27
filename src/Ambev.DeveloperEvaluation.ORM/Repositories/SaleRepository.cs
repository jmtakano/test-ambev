using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.DTO;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;
        private readonly ILogger<SaleRepository> _logger;

        public SaleRepository(DefaultContext context, ILogger<SaleRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(sale, cancellationToken);

            foreach (var item in sale.SalesItems)
            {
                await _context.SaleItems.AddAsync(item, cancellationToken);
            }
           
            await _context.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in sale.Events)
            {
                _logger.LogInformation("Event published: {Event}", domainEvent.GetType().Name);
                //Message broker -> _broker.Publish("topic name", domainEvent)....
            }

            return sale;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(id, cancellationToken);
            if (sale == null)
                return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<Sale?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sale?>> ListSalesAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistUser(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _context.Users.AnyAsync(x => x.Id ==  userId, cancellationToken);
        }

        public async Task<GetSaleProductDTO?> GetSaleProduct(Guid productId, CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .Where(x => x.Id == productId)
                .Select(x => new GetSaleProductDTO
                {
                    Title = x.Title,
                    Price = x.Price,
                }).AsNoTracking().FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
