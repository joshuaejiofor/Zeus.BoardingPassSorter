using System.Collections.Generic;
using System.Linq;
using Zeus.BoardingPassSorter.WebApi.Models;
using Zeus.BoardingPassSorter.WebApi.Services.Interfaces;

namespace Zeus.BoardingPassSorter.WebApi.Services
{
    public class SorterService : ISorterService
    {
        public IEnumerable<BoardingCard> SortBoardingCards (IEnumerable<BoardingCard> boardingCards)
        {
            var counter = 0;
            var totalBoardingCards = boardingCards.Count();
            var boardingCard = boardingCards.Where(c => !boardingCards.Select(b => b.To).Contains(c.From)).FirstOrDefault();
            boardingCard.TravelSequence = ++counter;

            while(counter < totalBoardingCards)
            {
                boardingCard = boardingCards.Where(c => c.From == boardingCard.To).FirstOrDefault();
                boardingCard.TravelSequence = ++counter;
            }

            return boardingCards.OrderBy(c => c.TravelSequence);
        }
    }
}
