using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBasketball.Data
{
    public class Player
    {
        public int defaultPositionId { get; set; }
        public bool droppable { get; set; }
        public List<int> eligibleSlots { get; set; }
        public string firstName { get; set; }
        public string fullName { get; set; }
        public int id { get; set; }
        public string lastName { get; set; }
        public ownership ownership { get; set; }
        public int proTeamId { get; set; }
        public int universeId { get; set; }

        public Player(int defaultPositionId, bool droppable, List<int> eligibleSlots, string firstName, string fullName, int id, string lastName, ownership ownership, int proTeamId, int universeId)
        {
            this.defaultPositionId = defaultPositionId;
            this.droppable = droppable;
            this.eligibleSlots = eligibleSlots;
            this.firstName = firstName;
            this.fullName = fullName;
            this.id = id;
            this.lastName = lastName;
            this.ownership = ownership;
            this.proTeamId = proTeamId;
            this.universeId = universeId;
        }

    }
}
