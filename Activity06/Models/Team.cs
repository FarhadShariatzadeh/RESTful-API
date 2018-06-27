using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity06.Models
{
    public class Team
    {
        public string TeamName { get; set; }
        public string TeamPlayed { get; set; }
        public string TeamPoints { get; set; }
        public List<Player> LeagueTopScoredPlayers { get; set; }


    }
}