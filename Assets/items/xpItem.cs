using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpItem : items
{
    public int xpP = 40;

    public xpItem()
    {
        itemName = "Xp Pot";
    }

    public override void UseItem(playerProps playerprops)
    {
        playerprops.PlayerEXP += xpP;
    }
}
