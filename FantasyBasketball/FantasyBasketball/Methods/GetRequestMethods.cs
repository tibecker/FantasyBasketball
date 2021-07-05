using FantasyBasketball.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FantasyBasketball.Methods
{
    public class GetRequestMethods
    {
        //Create a new RestClient to make REST requests using the RestSharp library
        private readonly IRestClient client = new RestClient();

        // Cookie Data (specific for my ESPN account)
        private readonly string espn_s2 = "AECRiHCYzg0TCklvSP0/v7iZEvT1Dfynhj7On3jUL1SVQMkxN4D0GAY4M1vCTcgSY2Zkva/AjSTSjdKzhQbn89LF+Tu5VYZS6MyhFTdwL+sp/LuS4L2Khmtt8VML4Hw2iQbLx1DwS64OmcuuW6RKRHAwxVTlnuYpCnfFMKY5L6j7Bhzo8oTs15WU2LBcaAT2P53OLW51eqo46lLKW/3dBMdFPwHLLprz9H5H1deq+3Y1J/NUoiJkG5WmbXJywHfBQ2YvEC/uHlTmcd5W2ZHjI0Vu";
        private readonly string SWID = "BAA65DF3-CA07-4D36-A785-684BE1CDD9E4";
        CookieContainer cc = new CookieContainer();  //Pull in System.Net

        //Endpoints
        Uri playerInfo = new Uri("https://fantasy.espn.com/apis/v3/games/fba/seasons/2021/players?view=players_wl");


        Uri playerInfoTim = new Uri("https://fantasy.espn.com/apis/v3/games/fba/seasons/2021/segments/0/leagues/76211349?rosterForTeamId=2&view=mRoster");


        //public List<Player> GetPlayers()
        //{
        //    Uri uri = playerInfo;
        //    RestRequest request = new RestRequest(uri);

        //    IRestResponse<List<Player>> response = client.Get<List<Player>>(request);
        //    List<Player> listOfPlayers = response.Data;

        //    GetPlayers2();

        //    return listOfPlayers;
        //}

        public List<Player> GetPlayers2()
        {
            Uri uri = playerInfoTim;
            RestRequest request = new RestRequest(uri);
            cc.Add(new Cookie("espn_s2", espn_s2) { Domain = uri.Host });
            cc.Add(new Cookie("SWID", SWID) { Domain = uri.Host });
            List<Player> listOfPlayers = new List<Player>();
            client.CookieContainer = cc;

            IRestResponse<string> response = client.Get<string>(request);
            string rawData = response.Data;

            // Add each players full name, id, and injury status to the list
            string[] myArray = rawData.Split("\"fullName\":");
            for (int i = 1; i < myArray.Length; i ++)
            {
                Player player = new Player();
                string[] tempArray = myArray[i].Split(',');
                player.FullName = tempArray[0].Substring(1, tempArray[0].Length - 2);
                player.Id = Convert.ToInt32(tempArray[1].Substring(5));
                player.IsInjured = Convert.ToBoolean(tempArray[2].Substring(10));
                player.ProTeamId = Convert.ToInt32(tempArray[12].Substring(12));

                listOfPlayers.Add(player);
            }



            return listOfPlayers;
        }




    }
}
