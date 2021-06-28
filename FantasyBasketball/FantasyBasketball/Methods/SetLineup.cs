using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBasketball.Methods
{
    public class SetLineup
    {

        /*
        
        1. Store SWID and espn_s2 cookies in database
            a. Also store teamId, teamName, owner, etc.
        2. Everyday in the morning/early afternoon run program
        3. GET players data from each team in the league (6 API calls)
            a. Data: player averages, player injury status, player name, player id, teamId
            b. Also have to determine which players have a game today (maybe use a different API?) nba.com
        4. Use player data to rank all players that can play today
            a. Use counter to track how many players have played for a given week
        5. Make a POST request to set the lineups for that day
            a. Maybe first clear out lineups (so that there is no maximum limit)
        6. Use Windows task scheduler to run this at the same time everyday


        */





    }
}
