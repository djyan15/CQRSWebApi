using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRSWebApi.Context;
using CQRSWebApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSWebApi.Features.ProductFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
        {
            private readonly IApplicationContext _context;

            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query,
                CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if (productList == null)
                {
                    return null;
                }

                return productList.AsReadOnly();
            }
        }
    }

}
