using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject API;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            API.GetComponent<CharacterUpdater>().ApiRequest("updateCharacterData");
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
