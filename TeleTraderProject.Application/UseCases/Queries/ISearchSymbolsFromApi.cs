using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleTraderProject.Application.Dto;

namespace TeleTraderProject.Application.UseCases.Queries
{
    public interface ISearchSymbolsFromApi : IQueryWithSearchFromApi<IEnumerable<string>, IEnumerable<SymbolWithQuoteDto>>
    {
    }
}
