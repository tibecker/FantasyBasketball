using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyBasketball.Data;
using FantasyBasketball.Methods;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FantasyBasketball
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<List<Player>> TeamInfo =  GetRequestMethods.GetRosterData();
            PostMethods.PostRosterChanges(TeamInfo);
        }
    }
}
