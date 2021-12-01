using System.Collections.Generic;
using Zeus.BoardingPassSorter.WebApi.Models;

namespace Zeus.BoardingPassSorter.WebApi.Services.Interfaces
{
    public interface ISorterService
    {
        IEnumerable<BoardingCard> SortBoardingCards(IEnumerable<BoardingCard> boardingCards);
    }
}
