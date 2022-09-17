using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeleTraderProject.Application.Dto;
using TeleTraderProject.Application.UseCases.Queries;

namespace Implementation.UseCases
{
    public class SearchSymbolsFromApi : ISearchSymbolsFromApi
    {
        private ISearchSymbolsFromXml _searchXml;
        private HttpClient _client;
        public SearchSymbolsFromApi(ISearchSymbolsFromXml searchXml, HttpClient client)
        {
            _searchXml = searchXml;
            _client = client;
        }
        public async Task<IEnumerable<SymbolWithQuoteDto>> Execute(IEnumerable<string> request)
        {
            var searched = _searchXml.Execute(request);
            var dtos = new List<SymbolWithQuoteDto>();
            foreach (var ticker in searched)
            {
                dtos.Add(new SymbolWithQuoteDto
                {
                    Id = ticker.Id,
                    Name = ticker.Name,
                    Ticker = ticker.Ticker
                });
            }

            var distinctTickers = searched.Select(x => "t" + x.Ticker).Distinct().ToList();
            var tickers  = string.Join(",", distinctTickers);
            
            _client.BaseAddress = new Uri("https://api-pub.bitfinex.com/v2/tickers");
            var uri = _client.BaseAddress + "?symbols=";


            HttpResponseMessage response = await _client.GetAsync(uri + tickers);
            var searchedFromApi = JsonConvert.DeserializeObject<List<List<string>>>(await response.Content.ReadAsStringAsync());

            
           foreach(var dto in dtos)
            {
                dto.Bid = float.Parse(searchedFromApi[0][2]);
                dto.Ask = float.Parse(searchedFromApi[0][4]);
                dto.High = float.Parse(searchedFromApi[0][9]);
                dto.Low = float.Parse(searchedFromApi[0][10]);
                dto.Last = float.Parse(searchedFromApi[0][7]);
            }
            return dtos;
        }
    }
}
