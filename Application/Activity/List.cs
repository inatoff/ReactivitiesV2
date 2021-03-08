
using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class List
    {
        public class Query: IRequest<List<Activity>> {}

        public class Handler: IRequestHandler<Query, List<Activity>>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync();
            }

        }

    }
}