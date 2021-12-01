using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Zeus.BoardingPassSorter.WebApi.Services;
using Zeus.BoardingPassSorter.WebApi.Services.Interfaces;
using Zeus.BoardingPassSorter.WebApi.Tests.Models;

namespace Zeus.BoardingPassSorter.WebApi.Tests.UnitTests
{
    public class UnitTestBase
    {        
        protected readonly IEnumerable<BoardingCardTestDto> _boardingCards;
        protected readonly ISorterService _sorterService;

        public UnitTestBase()
        {
            //Arrange for all tests.             
            _sorterService = new SorterService();
            _boardingCards = JsonConvert.DeserializeObject<IEnumerable<BoardingCardTestDto>>(File.ReadAllText(Path.Combine(@"TestData.json")));
        }
    }
}
