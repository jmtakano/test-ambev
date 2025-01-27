using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleProfiler : Profile
    {
        public GetSaleProfiler()
        {
            CreateMap<Sale, GetSaleResult>();
        }
    }
}
