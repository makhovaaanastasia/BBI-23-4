using System;
using System.Collections.Generic;

namespace ЛР_10_1
{
    public partial class TournamentTable
    {
        public void Disqual(Team team)
        {
            if (Teams.Contains(team))
            {
                Teams.Remove(team);
            }
        }
    }
}
