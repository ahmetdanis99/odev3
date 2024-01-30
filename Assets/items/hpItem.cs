using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpItem : items
{
    public int hpP = 20;

    public hpItem()
    {
        itemName = "HP Pot";
    }

    public override void UseItem(playerProps playerprops)
    {
        playerprops.PlayerHP += hpP;
    }
}
