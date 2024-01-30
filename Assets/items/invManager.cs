using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class invManager : MonoBehaviour
{
    public playerProps playerProps;
    public PlayerController controller;
    public static invManager invMan;
    public int hpCount = 0;
    public int xpCount = 0;
    public TMP_Text hpCtext, xpCtext;

    void Awake()
    {
        if (invMan == null)
        {
            invMan = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (controller.useEnv(KeyCode.Alpha1))
        {
            useHPpot();
        }
        if (controller.useEnv(KeyCode.Alpha1))
        {
            useXPpot();
        }
    }
    public void useHPpot()
    {
        if (hpCount <= 0)
        {
            playerProps.PlayerHP += 20;
            hpCount -= 1;
        }
    }
    public void useXPpot()
    {
        if (xpCount <= 0)
        {
            playerProps.PlayerEXP += 30;
            xpCount -= 1;
        }
    }
}
