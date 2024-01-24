using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    public StageChecker checker;
    public GameObject Time;
    public GameObject HP;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI hpText;

    public float time;
    public float hp;

    // Start is called before the first frame update
    private void Start()
    {
        timeText = Time.GetComponent<TextMeshProUGUI>();
        hpText = HP.GetComponent<TextMeshProUGUI>();
        List<float> temp = checker.getScore();
        timeText.SetText("Stage Time: " + System.Math.Floor(temp[0] * 100) / 100 + " seconds");
        hpText.SetText("Current HP: " + System.Math.Floor(temp[1] / 300 * 100) + "%");
    }
    void Awake()
    {
        
        timeText = Time.GetComponent<TextMeshProUGUI>();
        hpText = HP.GetComponent<TextMeshProUGUI>();
        List<float> temp = checker.getScore();
        timeText.SetText("Stage Time: " + System.Math.Floor(temp[0]*100)/100 + " seconds");
        hpText.SetText("Current HP: " + System.Math.Floor(temp[1] / 300 * 100) + "%");

    }
    public void setUp()
    {
        timeText = Time.GetComponent<TextMeshProUGUI>();
        hpText = HP.GetComponent<TextMeshProUGUI>();
        List<float> temp = checker.getScore();
        timeText.SetText("Stage Time: " + System.Math.Floor(temp[0] * 100) / 100 + " seconds");
        hpText.SetText("Current HP: " + System.Math.Floor(temp[1] / 300 * 100) + "%");
    }

}
