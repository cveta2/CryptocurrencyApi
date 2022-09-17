using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TeleTraderProject.Application.Dto;
using TeleTraderProject.Application.UseCases.Queries;

namespace Implementation.UseCases
{
    public class GetAllSymbols : IGetAllSymbols
    {
        public IEnumerable<SymbolDto> Execute()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("cryptos.xml");
            var symbolList = doc.SelectSingleNode("SymbolList");

            var listofchildnodes = new List<SymbolDto>();
            foreach (XmlNode node in symbolList)
            {
                var attr = node.Attributes;
                listofchildnodes.Add(
                    new SymbolDto
                    {
                        Id = attr[0].Value,
                        Name = attr[1].Value,
                        Ticker = attr[2].Value
                    });
            }

            return listofchildnodes;
        }
    }
}
