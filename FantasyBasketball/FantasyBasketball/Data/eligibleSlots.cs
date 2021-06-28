using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBasketball.Data
{
    public enum eligibleSlots
    {
        // Slots that are usable for our league
        // 4(C), 5(G), 6(F), 11(Util), 12(BE), 13(DL/IR)

        PG = 0,
        SG = 1,
        SF = 2,
        PF = 3,
        C = 4,
        G = 5,
        F = 6,
        SG_SF = 7,
        G_F = 8,
        PF_C = 9,
        F_C = 10,
        Util = 11, 
        BE = 12,
        DL_IR = 13
    }
}
