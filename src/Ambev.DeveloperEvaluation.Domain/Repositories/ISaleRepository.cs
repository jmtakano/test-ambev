using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        /// <summary>
        /// Creates a new sale in the repository
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale</returns>
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update a sale in the repository
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created user</returns>
        Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a sale by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a sale by their email address
        /// </summary>
        /// <param name="email">The email address to search for</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, null otherwise</returns>
        Task<Sale?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// List paginated sales
        /// </summary>
        /// <param name="pageIndex">The page index number</param>
        /// <param name="pageSize">The page size number</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale if found, empty list otherwise</returns>
        Task<IEnumerable<Sale?>> ListSalesAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a sale from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if sale user was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Validate if exist user customer.
        /// </summary>
        /// <param name="id">The unique identifier of the user to check if exist.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if sale user exist, false if not found</returns>
        Task<bool> ExistUser(Guid userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Product Amount
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>SaleProductDTO if sale product exist, null if not found</returns>
        Task<GetSaleProductDTO?> GetSaleProduct(Guid productId, CancellationToken cancellationToken = default);
    }
}
