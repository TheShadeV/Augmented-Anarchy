
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using static Unity.Burst.Intrinsics.Arm;
using static UnityEngine.UIElements.UxmlAttributeDescription;
/*
public class DatabaseManager : MonoBehaviour
{
    private const string apiUrl = "https://swapi.dev/api/people/1/"; // Példa karakter URL-je

    void Start()
    {
        StartCoroutine(SendGetRequest());
    }

    IEnumerator SendGetRequest()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(apiUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Hiba történt a kérés küldése során: " + www.error);
            }
            else
            {
                // A választ itt megjelenítjük a Debug.Log segítségével
                Debug.Log("Sikeres kérés!");
                Debug.Log("Válasz: " + www.downloadHandler.text);

                // Kezeld a választ, és dolgozd fel a JSON adatokat
                ParseJsonResponse(www.downloadHandler.text);
            }
        }
    }

    void ParseJsonResponse(string jsonResponse)
    {
        // Példa: JSON deserializálás és adatok kiírása
        CharacterData characterData = JsonUtility.FromJson<CharacterData>(jsonResponse);

        if (characterData != null)
        {
            Debug.Log("Karakter neve: " + characterData.name);
            Debug.Log("Születési év: " + characterData.birth_year);
            // További karakter adatait is kiírhatod itt
        }
        else
        {
            Debug.LogError("JSON deserializálási hiba.");
        }
    }

    [System.Serializable]
    public class CharacterData
    {
        public string name;
        public string birth_year;
        // További karakter tulajdonságokat is felveheted ide a JSON struktúrának megfelelően
    }
}
*/
 using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Net.Http.Headers;
using TMPro;
using MySqlX.XDevAPI.Common;
using System.Linq;

public class ApiRequestExample : MonoBehaviour
{
    private const string apiUrl = "http://localhost/reg4/backend/ApiRequest.php"; // Cél API végpont URL-je

    void Start()
    {
    }
    

    IEnumerator SendPostRequest(string method)
    {

        Transform StartMenu = GameObject.Find("Start-Menu").transform;
        if(method == "login")
        {
            string[] Data = getLoginData();
            string username = Data[0];
            string password = Data[1];

            WWWForm form = new WWWForm();
            form.AddField("mode","login");
            form.AddField("username", username);
            form.AddField("password", password);

            using (UnityWebRequest www = UnityWebRequest.Post(apiUrl, form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Hiba történt a kérés küldése során: " + www.error);
                }
                else
                {
                    // A választ itt megjelenítjük a Debug.Log segítségével
                    Debug.Log("Sikeres kérés!");
                    Debug.Log("Válasz: " + www.downloadHandler.text);

                    // Kezeld a választ, és ellenőrizd a kívánt feltételt
                    bool isResponseTrue = www.downloadHandler.text.Trim().Split('"')[11].ToLower() == "true";
                    Debug.Log("A válasz true vagy false? " + isResponseTrue);

                    if (isResponseTrue)
                    {
                        GameObject MainMenu = StartMenu.Find("MainMenu").gameObject;
                        GameObject Login_Screen = StartMenu.Find("Login_Screen").gameObject;

                        MainMenu.SetActive(true);
                        Login_Screen.SetActive(false);
                    }
                }
            }
        }
        else if(method == "register")
        {
            string[] Data = getRegistrationData();
            if(true)
            {
                Debug.Log("doing");
                string email = Data[0];
                string username = Data[1];
                string password = Data[2];
                WWWForm form = new WWWForm();
                form.AddField("mode", "register");
                form.AddField("email", email);
                form.AddField("username", username);
                form.AddField("password", password);
                using (UnityWebRequest www = UnityWebRequest.Post(apiUrl, form))
                {
                    yield return www.SendWebRequest();

                    if (www.result != UnityWebRequest.Result.Success)
                    {
                        Debug.LogError("Hiba történt a kérés küldése során: " + www.error);
                    }
                    else
                    {
                        // A választ itt megjelenítjük a Debug.Log segítségével
                        Debug.Log("Sikeres kérés!");
                        Debug.Log("Válasz: " + www.downloadHandler.text);

                        // Kezeld a választ, és ellenőrizd a kívánt feltételt
                        bool isResponseTrue = www.downloadHandler.text.Trim().Split('"')[11].ToLower() == "true";
                        Debug.Log("A válasz true vagy false? " + isResponseTrue);

                        if (isResponseTrue)
                        {
                            GameObject MainMenu = StartMenu.Find("MainMenu").gameObject;
                            GameObject Login_Screen = StartMenu.Find("Register_Screen").gameObject;

                            MainMenu.SetActive(true);
                            Login_Screen.SetActive(false);
                        }
                    }
                }
            }

            
        }

    }
    static string ComputeSha512Hash(string input)
    {
        using (SHA512 sha512 = SHA512.Create())
        {
            byte[] hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Convert the byte array to a hexadecimal string
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                stringBuilder.Append(b.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }

    public void ApiRequest(string method)
    {
        StartCoroutine(SendPostRequest(method));
    }


    public string[] getLoginData()
    {
        Transform StartMenu = GameObject.Find("Start-Menu").transform;
        Transform LoginScreen = StartMenu.Find("Login_Screen");
        string username = LoginScreen.Find("Username Fields").Find("Username").gameObject.GetComponent<TMP_InputField>().text;
        string password = ComputeSha512Hash(LoginScreen.Find("Password Fields").Find("Password").gameObject.GetComponent<TMP_InputField>().text);
        string[] result = new string[] {username,password};
        return result;
    }

    public string[] getRegistrationData()
    {
        Transform StartMenu = GameObject.Find("Start-Menu").transform;
        Transform RegisterScreen = StartMenu.Find("Register_Screen");
        string emailField = RegisterScreen.Find("Email Fields").Find("Email").gameObject.GetComponent<TMP_InputField>().text;
        string usernameField = RegisterScreen.Find("Username Fields").Find("Username").gameObject.GetComponent<TMP_InputField>().text;
        string passwordField = ComputeSha512Hash(RegisterScreen.Find("Password Fields").Find("Password").gameObject.GetComponent<TMP_InputField>().text);
        string password_confirmField = ComputeSha512Hash(RegisterScreen.Find("Password Confirm Fields").Find("Password_Confirm").gameObject.GetComponent<TMP_InputField>().text);

        string[] result = new string[] {};
        if(passwordField == password_confirmField && emailField != "" && usernameField != "" && passwordField != "")
        {
            return new string[] {emailField,usernameField, passwordField};
        }
        else
        {
            return new[] {"Fos"}; 
        }
    }
}
