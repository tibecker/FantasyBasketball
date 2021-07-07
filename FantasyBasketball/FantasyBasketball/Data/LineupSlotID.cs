using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBasketball.Data
{
    public enum LineupSlotID
    {
        // Slots that are usable for our league
        // 4(C), 5(G), 6(F), 11(Util), 12(BE), 13(DL/IR)

        C = 4,
        G = 5, 
        F = 6,
        UTL = 11,
        BE = 12,
        IR = 13
    }
}
