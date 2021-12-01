using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Zeus.BoardingPassSorter.WebApi.Models;
using Zeus.BoardingPassSorter.WebApi.Services.Interfaces;

namespace Zeus.BoardingPassSorter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardingPassSorterController : ControllerBase
    {
        private readonly ISorterService _sorterService;

        public BoardingPassSorterController(ISorterService sorterService)
        {
            _sorterService = sorterService;
        }

        [HttpPost]
        public IActionResult Post(IEnumerable<BoardingCard> boardingCards)
        {
            try
            {
                var result = new List<string>();
                _sorterService.SortBoardingCards(boardingCards).ToList().ForEach(boardingCard => result.Add(boardingCard.ToString()));

                result.Add($"{result.Count + 1} You have arrived at your final destination.");

                return Ok(result);
            }
            catch(Exception ex)
            {
                var problem = ex.InnerException?.ToString() ?? ex.Message.ToString();
                return BadRequest(problem);
            }
        }

    }
}
