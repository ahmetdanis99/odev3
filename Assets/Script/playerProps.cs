using UnityEngine;

public class playerProps : MonoBehaviour
{
    private float playerHP = 30;
    public float PlayerHP
    {
        get
        {
            return playerHP;
        }
        set
        {
            if (playerHP <= 0)
            {
                playerHP = 0;
            }
            else if (playerHP > 30)
            {
                playerHP = 30;
            }
            else
            {
                playerHP = value;
            }
        }
    }
    private float playerEXP;
    public float PlayerEXP
    {
        get
        {
            return playerEXP;
        }
        set
        {
            if (playerEXP <= 0)
            {
                playerEXP = 0;
            }
            else
            {
                playerEXP = value;
            }
        }

    }
}
