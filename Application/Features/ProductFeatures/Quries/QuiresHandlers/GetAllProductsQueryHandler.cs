using Application.Interfaces;
using Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Quries.QuiresHandlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductDbContext _productDbContext;

        public GetAllProductsQueryHandler(IProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery Query, CancellationToken cancellationToken)
        {
            var productList = await _productDbContext.Products.ToListAsync();
            if (productList == null)
                return null;
            return productList.AsReadOnly();
        }
    }
}
