using Application.Interfaces;
using Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.CommandsHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductDbContext _productDbContext;

        public CreateProductCommandHandler(IProductDbContext productDbContext)
        {
            this._productDbContext = productDbContext;
        }
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                BarCode = command.BarCode,
                Description = command.Description,
                Rate = command.Rate

            };
             _productDbContext.Products.Add(product);
            await _productDbContext.SaveChangesAsync();
            return product.Id;
        }
    }
}
