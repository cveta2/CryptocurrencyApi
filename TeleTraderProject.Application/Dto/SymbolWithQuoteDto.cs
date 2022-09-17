using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleTraderProject.Application.Dto
{
    public class SymbolWithQuoteDto : SymbolDto
    {
        public float Last { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Bid { get; set; }
        public float Ask { get; set; }
    }
}
