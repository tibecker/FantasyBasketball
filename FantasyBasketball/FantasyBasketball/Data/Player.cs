using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBasketball.Data
{
    public class Player
    {
        /* Data that is relevant

        * eligibleSlots (a list of which spots a player can be placed in)
        * fullName (the first and last name of player)
        * id (unique id for each player)
        * injured (boolean for where player is injured or not)
        * injuryStatus (string - either OUT or ACTIVE) -- may not need both injury properties
        * proTeamId (the team that the player is on)
        * lineupSlotId (where player is currently in lineup)
        * 1st appliedAverage - 7 day average (10%)
        * 2nd appliedAverage - 15 day average (20%)
        * 3rd appliedAverage - season average (50%)
        * 4th appliedAverage - projected average (disregard this)
        * 5th appliedAverage - 30 day average (20%)

       
        */
        public string FullName { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int ProTeamId { get; set; }
        public ownership ownership { get; set; }
        public List<int> eligibleSlots { get; set; }
        public int universeId { get; set; }
        public double SevenDayAvg { get; set; }
        public double FifteenDayAvg { get; set; }
        public double SeasonAvg { get; set; }
        public double ProjectedAvg { get; set; }
        public double ThirtyDayAvg { get; set; }

        //public Player(int defaultPositionId, bool droppable, List<int> eligibleSlots, string firstName, string fullName, int id, string lastName, ownership ownership, int proTeamId, int universeId)
        //{
        //    this.defaultPositionId = defaultPositionId;
        //    this.droppable = droppable;
        //    this.eligibleSlots = eligibleSlots;
        //    this.firstName = firstName;
        //    this.fullName = fullName;
        //    this.id = id;
        //    this.lastName = lastName;
        //    this.ownership = ownership;
        //    this.proTeamId = proTeamId;
        //    this.universeId = universeId;
        //}

    }
}
