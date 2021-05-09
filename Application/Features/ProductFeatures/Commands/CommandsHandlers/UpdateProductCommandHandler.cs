using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.CommandsHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,int>
    {
        private readonly IProductDbContext _productionDbContetx;
        public UpdateProductCommandHandler(IProductDbContext productionDbContetx)
        {
            this._productionDbContetx = productionDbContetx;
        }
        public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productionDbContetx.Products.FindAsync(command.Id);

            if (product == null)return default;
            product.BarCode = command.BarCode;
            product.Name = command.Name;
            product.Rate = command.Rate;
            product.Description = command.Description;

            await _productionDbContetx.SaveChangesAsync();
            return product.Id;




        }
    }
}
