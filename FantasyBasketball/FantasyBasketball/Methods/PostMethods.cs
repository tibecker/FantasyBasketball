using FantasyBasketball.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FantasyBasketball.Methods
{
    public static class PostMethods
    {
        //Create a new RestClient to make REST requests using the RestSharp library
        private static readonly IRestClient client = new RestClient();

        // Cookie Data (specific for my ESPN account)
        private static readonly string espn_s2 = "AECRiHCYzg0TCklvSP0/v7iZEvT1Dfynhj7On3jUL1SVQMkxN4D0GAY4M1vCTcgSY2Zkva/AjSTSjdKzhQbn89LF+Tu5VYZS6MyhFTdwL+sp/LuS4L2Khmtt8VML4Hw2iQbLx1DwS64OmcuuW6RKRHAwxVTlnuYpCnfFMKY5L6j7Bhzo8oTs15WU2LBcaAT2P53OLW51eqo46lLKW/3dBMdFPwHLLprz9H5H1deq+3Y1J/NUoiJkG5WmbXJywHfBQ2YvEC/uHlTmcd5W2ZHjI0Vu";
        private static readonly string SWID = "BAA65DF3-CA07-4D36-A785-684BE1CDD9E4";
        private static CookieContainer cc = new CookieContainer();  //Pull in System.Net

        private static readonly Uri timsTeam = new Uri("https://fantasy.espn.com/apis/v3/games/fba/seasons/2021/segments/0/leagues/76211349?rosterForTeamId=4&view=mRoster");

        private static readonly Uri transaction = new Uri("https://fantasy.espn.com/apis/v3/games/fba/seasons/2021/segments/0/leagues/76211349/transactions/");

        public static void PostRosterChanges(List<List<Player>> teamInfo)
        {
            Uri u = transaction;
            RestRequest request = new RestRequest(u);
            cc.Add(new Cookie("espn_s2", espn_s2) { Domain = u.Host });
            cc.Add(new Cookie("SWID", SWID) { Domain = u.Host });
            client.CookieContainer = cc;

            //request.AddJsonBody(
            //    new
            //    {
            //        isLeagueManager = false,
            //        executionType = "EXECUTE",
            //        scoringPeriod = 147,
            //        teamId = 4,
            //        type = "ROSTER", 
            //    }          
            //);

            bool isLeagueManger = false;
            int teamId = 4;
            string memberId = "{BAA65DF3-CA07-4D36-A785-684BE1CDD9E4}";
            int scoringPeriodId = 147;
            string executionType = "EXECUTE";
            string playerId = "4277811";
            List<string> type = new List<string>();
            type.Add("ROSTER");
            type.Add("LINEUP");
            int fromLineupSlotId = 12;
            int toLineupSlotId = 5;

            string the = "";


            //request.AddJsonBody(isLeagueManger);
            //request.AddJsonBody(teamId);
            //request.AddJsonBody(memberId);
            //request.AddJsonBody(scoringPeriodId);

            // Struggling with getting transaction to work

          

            string t = "{ \"isLeagueManager\":false,\"teamId\":4,\"type\":\"ROSTER\",\"memberId\":\"{BAA65DF3-CA07-4D36-A785-684BE1CDD9E4}\",\"scoringPeriodId\":147,\"executionType\":\"EXECUTE\",\"items\":[{ \"playerId\":4277811,\"type\":\"LINEUP\",\"fromLineupSlotId\":5,\"toLineupSlotId\":12}]}";

            request.AddJsonBody(t);

            IRestResponse<string> response = client.Post<string>(request);

            string rawData = response.Data;
            //string r = "{isLeagueManager:false, executionType:EXECUTE,"id":"03f895e1 - fd1a - 4bec - 8825 - b238c60b0b1f","isActingAsTeamOwner":false,"isLeagueManager":false,"isPending":false,"items":[{"fromLineupSlotId":12,"fromTeamId":0,"isKeeper":false,"overallPickNumber":0,"playerId":4277811,"toLineupSlotId":5,"toTeamId":0,"type":"LINEUP"}],"memberId":"{ BAA65DF3 - CA07 - 4D36 - A785 - 684BE1CDD9E4}
            //","proposedDate":1625705502255,"rating":0,"scoringPeriodId":147,"skipTransactionCounters":false,"status":"EXECUTED","subOrder":0,"teamId":4,"type":"ROSTER"}";


            // {"isLeagueManager":false,"teamId":4,"type":"ROSTER","memberId":"{BAA65DF3-CA07-4D36-A785-684BE1CDD9E4}","scoringPeriodId":147,"executionType":"EXECUTE","items":[{"playerId":4277811,"type":"LINEUP","fromLineupSlotId":12,"toLineupSlotId":5}]}


        }

        /*

        {"bidAmount":0,
        "executionType":"EXECUTE",
        "id":"03f895e1-fd1a-4bec-8825-b238c60b0b1f",
        "isActingAsTeamOwner":false,
        "isLeagueManager":false,
        "isPending":false,
         "items":[
            {"fromLineupSlotId":12,
            "fromTeamId":0,
            "isKeeper":false,
            "overallPickNumber":0,
            "playerId":4277811,
            "toLineupSlotId":5,
            "toTeamId":0,"type":"LINEUP"}
        ],
        "memberId":"{BAA65DF3-CA07-4D36-A785-684BE1CDD9E4}",
        "proposedDate":1625705502255,"rating":0,
        "scoringPeriodId":147,
        "skipTransactionCounters":false,
        "status":"EXECUTED","subOrder":0,
        "teamId":4,
        "type":"ROSTER"}

        */
    }
}
