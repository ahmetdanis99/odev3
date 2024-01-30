using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudmanager : MonoBehaviour
{
    public Slider hpSlider;
    public Slider expSlider;
    public playerProps playerProps;
    public static hudmanager hudcont;

    void Awake()
    {
        if (hudcont == null)
        {
            hudcont = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = playerProps.PlayerHP / 30;
        expSlider.value = playerProps.PlayerEXP / 100;
    }
}
