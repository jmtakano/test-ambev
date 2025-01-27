using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleCommand  : IRequest<GetSaleResult>
    {   /// <summary>
        /// The unique identifier of the user to retrieve
        /// </summary>
        public Guid Id { get; }

        public GetSaleCommand(Guid id)
        {
            Id = id;
        }
    }
}
