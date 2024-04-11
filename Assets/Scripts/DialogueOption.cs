using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEditor;

using UnityEngine;
using UnityEngine.UI;

public class DialogueOption : MonoBehaviour
{
    public Canvas PopUpWindow;
    public KeyCode popupKey = KeyCode.F;

    private bool canOpenPopup = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canOpenPopup = true;
            
            Debug.Log("Bent vagy!");
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canOpenPopup = false;
            PopUpWindow.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F) && canOpenPopup)
        {
            PopUpWindow.gameObject.SetActive(true);
            Debug.Log("lenyomtad!");
        }
        Debug.Log("Update method called");
        if (canOpenPopup )
        {
            Debug.Log("Showing popup");
            if (PopUpWindow != null)
            {
              
            }
            else
            {
                Debug.LogError("Popup canvas reference is null!");
            }
        }

        
    }
}

