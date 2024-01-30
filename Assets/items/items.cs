using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class items : MonoBehaviour
{
    public playerProps playerprops;
    public string itemName;
    public GameObject prefab;

    public abstract void UseItem(playerProps playerprops);
}
