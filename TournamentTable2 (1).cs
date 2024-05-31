using System;
using System.Collections.Generic;

namespace ЛР_10_1
{
    public partial class TournamentTable
    {
        public Team GetBest()
        {
            BubbleSortByPoints();
            return Teams[0];
        }

        public List<Team> GetBest(int n)
        {
            BubbleSortByPoints();
            return Teams.GetRange(0, Math.Min(n, Teams.Count));
        }
    }
}
