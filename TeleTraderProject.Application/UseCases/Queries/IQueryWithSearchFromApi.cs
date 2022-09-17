using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleTraderProject.Application.UseCases.Queries
{
    public interface IQueryWithSearchFromApi<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }
}
