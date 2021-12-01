using System.Collections.Generic;
using System.Linq;
using Xunit;
using Zeus.BoardingPassSorter.WebApi.Models;

namespace Zeus.BoardingPassSorter.WebApi.Tests.UnitTests
{
    public class SortServiceTests : UnitTestBase
    {
        [Fact]
        public void SortBoardingCards()
        {
            //Act
            var sortedBoardingCards = _sorterService.SortBoardingCards(_boardingCards);

            //Assert
            Assert.NotNull(sortedBoardingCards);
            Assert.IsAssignableFrom<IEnumerable<BoardingCard>>(sortedBoardingCards);
            Assert.Equal(sortedBoardingCards.Count(), _boardingCards.Count());

            var expectedSortedBoardingCards = _boardingCards.OrderBy(c => c.ActualSequence).ToList();

            var counter = 0;
            foreach(var boardingCard in expectedSortedBoardingCards)
            {
                Assert.Equal(boardingCard, sortedBoardingCards.ToArray()[counter++]);                
            }
        }
    }
}
