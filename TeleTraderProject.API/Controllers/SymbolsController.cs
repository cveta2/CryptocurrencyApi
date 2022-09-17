using Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using TeleTraderProject.Application.UseCases.Queries;
using Newtonsoft.Json;
using TeleTraderProject.Application.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeleTraderProject.API.Controllers
{
    [Route("symbols/")]
    [ApiController]
    public class SymbolsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public SymbolsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<SymbolsController>
        [HttpGet]
        [Route("all")]
        public IActionResult All([FromServices] IGetAllSymbols query)
        {
            return Ok(_handler.ExecuteQuery(query));
        }

        // GET api/<SymbolsController>/5
        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes([FromQuery] string[] id, [FromServices] ISearchSymbolsFromApi query)
        {
            var result = _handler.ExecuteQueryWithSearch(query, id);
            return Ok(result.Result);
        }
    }
}
