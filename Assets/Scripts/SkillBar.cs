using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour
{
    public Slider mb1Slider;
    public Slider mb2Slider;
    public Slider dashSlider;


    public PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        if (playerController.spellTimers.ContainsKey("ShockArrow"))
        {
            mb1Slider.value = playerController.spellTimers["ShockArrow"];
        }
        else
        {
            mb1Slider.value = 0f;
        }
        if (playerController.spellTimers.ContainsKey("ShockRoller"))
        {
            mb2Slider.value = playerController.spellTimers["ShockRoller"];
        }
        else
        {
            mb2Slider.value = 0f;
        }
        dashSlider.value = playerController.dodgeTimer;
    }
}
