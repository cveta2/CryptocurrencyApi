using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleTraderProject.Application.Dto;
using TeleTraderProject.Application.UseCases.Queries;

namespace Implementation.UseCases
{
    public class SearchSymbolsFromXml : ISearchSymbolsFromXml
    {
        private readonly IGetAllSymbols _query;
        public SearchSymbolsFromXml(IGetAllSymbols query)
        {
            _query = query;
        }

        public IEnumerable<SymbolDto> Execute(IEnumerable<string> request)
        {
            IEnumerable<SymbolDto> allSymbols = _query.Execute();

            IEnumerable<SymbolDto> symbols =  allSymbols.Where(x => request.Contains(x.Id)).ToList();

            return symbols;
        }
    }
}
