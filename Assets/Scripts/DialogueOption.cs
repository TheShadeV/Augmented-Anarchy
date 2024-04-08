using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEditor;

using UnityEngine;
using UnityEngine.UI;

public class DialogueOption : MonoBehaviour
{
    public GameObject uiGameObject;
    void Start()
    {
        uiGameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiGameObject.SetActive(true);
        }
    }
}
