using System;
using System.Collections;
using System.Collections.Generic;
using Org.BouncyCastle.Crypto;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CharacterUpdater : MonoBehaviour
{
    private const string apiUrl = "http://localhost/Augmented-Anarchy/backend/ApiRequest.php";
    // Start is called before the first frame update
    public Token token;
    void Start()
    {

    }

    IEnumerator SendPostRequest(string method)
    {


        if (method == "updateCharacterData")
        {
            int tokens = token.getToken();
            int health = GameObject.Find("Player").GetComponent<PlayerController>().totalHealth;

            WWWForm form = new WWWForm();
            form.AddField("mode", "updateCharacterData");
            form.AddField("token", tokens);
            form.AddField("health", health);

            using (UnityWebRequest www = UnityWebRequest.Post(apiUrl, form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Hiba történt a kérés küldése során: " + www.error);
                }
                else
                {
                    Debug.Log("Sikeres kérés!");
                    Debug.Log("Válasz: " + www.downloadHandler.text);

                    bool isResponseTrue = www.downloadHandler.text.Replace("\"", "").ToLower() == "true";
                    Debug.Log("A válasz true vagy false? " + isResponseTrue);

                    if (isResponseTrue)
                    {
                        GameObject.Find("Door").GetComponent<SceneSwitch>().LoadNextScene();
                    }
                    else
                    {
                        //showError(www.downloadHandler.text.Replace("\"", ""));
                    }
                }
            }
        }
        else if (method == "uploadMapScore")
        {

            //How can I get the current scenes build index?



            int user_id = token.getUserId();
            int map_id = SceneManager.GetActiveScene().buildIndex - 1;
            int health = GameObject.Find("Player").GetComponent<PlayerController>().totalHealth;
            int maptime = Convert.ToInt32(GameObject.Find("StageChecker").GetComponent<StageChecker>().getTime());
            int score = health / maptime * 1000;

            WWWForm form = new WWWForm();
            form.AddField("mode", "uploadMapScore");
            form.AddField("user_id", user_id);
            form.AddField("map_id", map_id);
            form.AddField("health", health);
            form.AddField("maptime", maptime);
            form.AddField("score", score);

            using (UnityWebRequest www = UnityWebRequest.Post(apiUrl, form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Hiba történt a kérés küldése során: " + www.error);
                }
                else
                {
                    Debug.Log("Sikeres kérés!");
                    Debug.Log("Válasz: " + www.downloadHandler.text);



                    bool isResponseTrue = www.downloadHandler.text.Replace("\"", "").ToLower() == "true";
                    Debug.Log("A válasz true vagy false? " + isResponseTrue);

                    if (isResponseTrue)
                    {
                        //
                    }
                    else
                    {
                        //showError(www.downloadHandler.text.Replace("\"", ""));
                    }
                }
            }


        }
        else if (method == "getCharacterData")
        {
            int tokens = token.getToken();

            WWWForm form = new WWWForm();
            form.AddField("mode", "getCharacterData");
            form.AddField("token", tokens);

            using (UnityWebRequest www = UnityWebRequest.Post(apiUrl, form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Hiba történt a kérés küldése során: " + www.error);
                }
                else
                {
                    Debug.Log("Sikeres kérés!");
                    Debug.Log("Válasz: " + www.downloadHandler.text);

                    bool isResponseTrue = true;
                    Debug.Log("A válasz true vagy false? " + isResponseTrue);
                    string[] datas = www.downloadHandler.text.Replace("\"", "").Split(',');

                    Dictionary<string, string> characterData = new Dictionary<string, string>();
                    foreach (var i in datas)
                    {
                        Debug.Log(i);
                        string[] needIt = i.Split(":");
                        if (needIt[0] == "health" || needIt[0] == "user_id")
                        {
                            characterData.Add(needIt[0], needIt[1]);
                        }
                    }





                    if (isResponseTrue)
                    {
                        Debug.Log("Sikeres karakter adatok lekérdezése!");
                        GameObject.Find("Player").GetComponent<PlayerController>().totalHealth = Convert.ToInt32(characterData["health"]);
                        token.setUserId(Convert.ToInt32(characterData["user_id"]));
                    }
                    else
                    {
                        //showError(www.downloadHandler.text.Replace("\"", ""));
                    }
                }
            }

        }
        else if (method == "healPlayer")
        {
            //Still under development
            PlayerController play = GameObject.Find("Player").GetComponent<PlayerController>();
            if (play.totalHealth < play.maxHealth)
            {
                int temp = play.maxHealth - play.totalHealth;
                if (temp < 50)
                {
                    play.totalHealth += temp;
                }
                else
                {
                    play.totalHealth += 50;
                }
            }

        }

    }
    public void ApiRequest(string method)
    {
        StartCoroutine(SendPostRequest(method));
    }


    public void showError(string error)
    {
        Transform StartMenu = GameObject.Find("Start-Menu").transform;
        Transform ErrorWindow = StartMenu.Find("Pop-Up_Window");
        ErrorWindow.gameObject.SetActive(true);

    }

    // Make a JSON deserialize method
    public void DeserializeJson(string json)
    {
        //Deserialize the json


    }
}

