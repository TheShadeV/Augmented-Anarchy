using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject PopUpBox;
    public Animator PopUp_anim;
    public TMP_Text PopUpText;

    public void PopUp(string text)
    {
        PopUpBox.SetActive(true);
        PopUpText.text = text;
        PopUp_anim.SetTrigger("pop");
    }
}
