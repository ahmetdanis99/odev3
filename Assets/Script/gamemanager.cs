using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;
    public Dictionary<string, int> defaultStats = new Dictionary<string, int>(){
        {"health",100},
        {"power",10}
    };
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
    public void statUpdate(){

    }

}
