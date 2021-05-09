using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.CommandsHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductDbContext _productionDbContetx;

        public DeleteProductCommandHandler(IProductDbContext productionDbContetx)
        {
            this._productionDbContetx = productionDbContetx;
        }
        public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productionDbContetx.Products.FindAsync(command.Id);
            if (product is null) return default;
             _productionDbContetx.Products.Remove(product);
            await _productionDbContetx.SaveChangesAsync();
            return product.Id;
        }
    }
}
