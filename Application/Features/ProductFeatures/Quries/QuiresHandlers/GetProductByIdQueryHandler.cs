using Application.Interfaces;
using Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Quries.QuiresHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {

        private readonly IProductDbContext _productDbContext;

        public GetProductByIdQueryHandler(IProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _productDbContext.Products.FindAsync(query.Id);
            if (product == null) return null;
            return product;
        }
    }
}
