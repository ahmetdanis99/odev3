using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playButton : MonoBehaviour
{
    public Button pButton;
    void Start()
    {
        pButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
}
