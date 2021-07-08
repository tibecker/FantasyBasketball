﻿using FantasyBasketball.Data;
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


        Uri playerInfoTim = new Uri("https://fantasy.espn.com/apis/v3/games/fba/seasons/2021/segments/0/leagues/76211349?rosterForTeamId=3&view=mRoster");


        //public List<Player> GetPlayers()
        //{
        //    Uri uri = playerInfo;
        //    RestRequest request = new RestRequest(uri);

        //    IRestResponse<List<Player>> response = client.Get<List<Player>>(request);
        //    List<Player> listOfPlayers = response.Data;

        //    GetPlayers2();

        //    return listOfPlayers;
        //}

        // ISSUES ARE CAUSED BY ROOKIES - THEY DON'T HAVE 2020 DATA TO PULL FROM

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
                player.IsActive = !Convert.ToBoolean(tempArray[2].Substring(10));

                if (player.FullName == "Tyrese Haliburton" || player.FullName == "Anthony Edwards" || player.FullName == "LaMelo Ball" || player.FullName == "Immanuel Quickley")
                {
                    player.IsRookie = true;
                }

                listOfPlayers.Add(player);
            }

            string[] myLineupArray = rawData.Split("\"lineupSlotId\":");
            for (int i = 1; i < myLineupArray.Length; i++)
            {
                Player player = new Player();
                string[] tempArray = myLineupArray[i].Split(',');
                player.LineupSlotID = (LineupSlotID)Convert.ToInt32(tempArray[0]);
                listOfPlayers[i - 1].LineupSlotID = player.LineupSlotID;
            }

            // Add Pro team for each player
            string[] myTeamArray = rawData.Split("\"proTeamId\":");
            for (int i = 1; i < myTeamArray.Length; i = i + 8)
            {
                string[] tempArray = null;
                Player player = new Player();
                player = listOfPlayers[(i - 1) / 8];

                if (listOfPlayers[((i - 1) / 8)-1].IsRookie)
                {
                    tempArray = myTeamArray[i-2].Split(',');
                }
                else
                {
                    tempArray = myTeamArray[i].Split(',');
                }
                player.Team = (Team)Convert.ToInt32(tempArray[0]);
            }

            // Add eligible lineup slots for each player
            string[] myEligibilityArray = rawData.Split("\"eligibleSlots\":");
            for (int i = 1; i < myEligibilityArray.Length; i++)
            {
                Player player = new Player();
                string[] tempArray = myEligibilityArray[i].Split("\"firstName\":");
                string tempString = tempArray[0].Substring(1, tempArray[0].Length - 3);
                string [] tempStringArray = tempString.Split(',');
                for (int j = 0; j < tempStringArray.Length; j++)
                {
                    int x = Convert.ToInt32(tempStringArray[j]);

                    // Add addtional check to see if player is active.
                    // If player is active, don't make IR an eligible slot.
                    if (x == 4 || x == 5 || x ==  6 || x == 11 || x == 12 || x == 13){
                        listOfPlayers[i - 1].EligibleSlots.Add((LineupSlotID)x);
                    }
                }
            }

            // Add player averages for each player
            string[] averagesArray = rawData.Split("\"appliedAverage\":");
            for (int i= 1; i < averagesArray.Length - 2; i=i + 7)
            {
                //// 7 Day Average
                //string [] temp7DayArray = averagesArray[i].Split(',');
                //listOfPlayers[(i - 1) / 7].SevenDayAvg = Convert.ToDouble(temp7DayArray[0]);

                //// 15 Day Average
                //string[] temp15DayArray = averagesArray[i+1].Split(',');
                //listOfPlayers[(i - 1) / 7].FifteenDayAvg = Convert.ToDouble(temp15DayArray [0]);

                // Season Average
                string[] tempSeasonArray = averagesArray[i + 3].Split(',');
                listOfPlayers[(i - 1) / 7].SeasonAvg = Convert.ToDouble(tempSeasonArray[0]);
            }

            return listOfPlayers;
        }




    }
}
