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
        private readonly string espn_s2 = "AEBJOP3VvFUwwel%2Bqy%2FADdhVrdjiFTjkv0yPBlyo7KivAifJhh2pS7gFx9Hgm956neQ40Z692%2FZvJ9yGxM9TJMcd9CHmEJ8fdol7RgcIEpfLhJG3LKxPwFLWahX39jei%2BC6Zunr4R1CVLjlCwlaFPOGzNWU4RXIBh%2B5OU9EkCnPVE6NPfeguFGLScoTWStkyWud1AjtGpuZWhCReruRAEkFAqj2nNtH1tTS6FyMstNqL9vOCGUHAVXcJmyCl1cdHvVEd5P8T2NDlXAGYFx3mva%2FA";
        private readonly string SWID = "BAA65DF3-CA07-4D36-A785-684BE1CDD9E4";
        CookieContainer cc = new CookieContainer();  //Pull in System.Net

        //Endpoints
        Uri playerInfo = new Uri("https://fantasy.espn.com/apis/v3/games/fba/seasons/2021/players?view=players_wl");



        public List<Player> GetPlayers()
        {
            Uri uri = playerInfo;
            RestRequest request = new RestRequest(uri);
            cc.Add(new Cookie("espn_s2", espn_s2) { Domain = uri.Host });
            cc.Add(new Cookie("SWID", SWID) { Domain = uri.Host });

            IRestResponse<List<Player>> response = client.Get<List<Player>>(request);
            List<Player> listOfPlayers = response.Data;

            return listOfPlayers;
        }

    }
}
