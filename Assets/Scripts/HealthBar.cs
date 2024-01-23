using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject player;
    public PlayerController playerController;
    public Slider mySlider;

    private void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
        maxHealth = playerController.totalHealth;
        currentHealth = maxHealth;
        mySlider = GetComponent<Slider>();
        mySlider.value = currentHealth;
    }

    void Update()
    {
        if (playerController.totalHealth < currentHealth || playerController.totalHealth > currentHealth)
        {
            mySlider.value = playerController.totalHealth;
        }
    }
}
