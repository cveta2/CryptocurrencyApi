using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleTraderProject.Application.UseCases.Queries;

namespace Implementation.UseCases
{
    public class UseCaseHandler
    {
       public TResponse ExecuteQuery<TResponse>(IQuery<TResponse> query)
       {
          return query.Execute();
       }
        public Task<TResponse> ExecuteQueryWithSearch<TRequest, TResponse>(IQueryWithSearchFromApi<TRequest, TResponse> query, TRequest request)
        {
            return query.Execute(request);
        }
    }
}
