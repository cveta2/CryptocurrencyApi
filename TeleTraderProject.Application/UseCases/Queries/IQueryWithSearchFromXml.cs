using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleTraderProject.Application.UseCases.Queries
{
    public interface IQueryWithSearchFromXml<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
