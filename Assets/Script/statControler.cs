using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class statControler : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI powerText;
    public Button healthButton;
    public Button powerButton;

    // Start is called before the first frame update
    void Start()
    {
        healthButton.onClick.AddListener(healthP);
        powerButton.onClick.AddListener(powerP);
    }

    // Update is called once per frame
    void Update()
    {
        paneluseEffect();
    }

    public void paneluseEffect()
    {
        healthText.text = gamemanager.instance.defaultStats["health"].ToString();
        powerText.text = gamemanager.instance.defaultStats["power"].ToString();
    }
    void healthP()
    {
        gamemanager.instance.defaultStats["health"] += 10;
    }
    void powerP()
    {
        gamemanager.instance.defaultStats["power"] += 10;
    }
}
