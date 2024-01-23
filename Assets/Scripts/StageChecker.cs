using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageChecker : MonoBehaviour
{

    public GameObject[] enemiesLeft;
    private float stageTime;
    private bool isTimerRunning;
    public GameObject endScreen;
    // Start is called before the first frame update
    void Start()
    {
        isTimerRunning = true;
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            stageTime = Time.time;
        }
        if(enemiesLeft.Length > 0)
        {
            enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
        }
        if(enemiesLeft.Length == 0 && isTimerRunning)
        {
            isTimerRunning = false;
            Debug.Log("Final Time: " + stageTime + " seconds");
            UpdateScores();
        }
    }
    private void UpdateScores()
    {
        endScreen.SetActive(true);
        endScreen.GetComponent<GetScore>().setUp();
        
    }
    public float getTime()
    {
        return stageTime;
    }
    public float getHP()
    {
        return GameObject.Find("Player").GetComponent<PlayerController>().totalHealth;
    }
    public List<float> getScore()
    {
        return new List<float>() { getTime(), getHP() };
    }
}
