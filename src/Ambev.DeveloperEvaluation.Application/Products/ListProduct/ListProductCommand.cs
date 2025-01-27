using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct
{
    public class ListProductCommand : IRequest<IEnumerable<ListProductResult>>
    {
        public int PageIndex { get; }
        public int PageSize { get; }

        public ListProductCommand(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
