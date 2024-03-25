
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.Security.Cryptography;
using TMPro;

public class ApiRequestExample : MonoBehaviour
{
    private const string apiUrl = "http://localhost/reg4/backend/ApiRequest.php";

    void Start()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    IEnumerator SendPostRequest(string method)
    {

        Transform StartMenu = GameObject.Find("Start-Menu").transform;
        if(method == "login")
        {
            string[] Data = getLoginData();
            if (Data[0] != "ERROR")
            {
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
                        Debug.Log("Sikeres kérés!");
                        Debug.Log("Válasz: " + www.downloadHandler.text);

                        bool isResponseTrue = www.downloadHandler.text.Replace("\"","").ToLower() == "true";
                        Debug.Log("A válasz true vagy false? " + isResponseTrue);

                        if (isResponseTrue)
                        {
                            GameObject MainMenu = StartMenu.Find("MainMenu").gameObject;
                            GameObject Login_Screen = StartMenu.Find("Login_Screen").gameObject;

                            MainMenu.SetActive(true);
                            Login_Screen.SetActive(false);
                        }
                        else
                        {
                            showError(www.downloadHandler.text.Replace("\"", ""));
                        }
                    }
                }
            }
        }
        else if(method == "register")
        {
            string[] Data = getRegistrationData();
            if (Data[0] != "ERROR")
            {
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
                        Debug.Log("Sikeres kérés!");
                        Debug.Log("Válasz: " + www.downloadHandler.text);



                        bool isResponseTrue = www.downloadHandler.text.Replace("\"", "").ToLower() == "true";
                        Debug.Log("A válasz true vagy false? " + isResponseTrue);

                        if (isResponseTrue)
                        {
                            GameObject MainMenu = StartMenu.Find("MainMenu").gameObject;
                            GameObject Login_Screen = StartMenu.Find("Register_Screen").gameObject;

                            MainMenu.SetActive(true);
                            Login_Screen.SetActive(false);
                            

                        }
                        else
                        {
                            showError(www.downloadHandler.text.Replace("\"", ""));
                        }
                    }
                }
            }

            
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    static string ComputeSha512Hash(string input)
    {
        using (SHA512 sha512 = SHA512.Create())
        {
            byte[] hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                stringBuilder.Append(b.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="method"></param>
    public void ApiRequest(string method)
    {
        StartCoroutine(SendPostRequest(method));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string[] getLoginData()
    {
        Transform StartMenu = GameObject.Find("Start-Menu").transform;
        Transform LoginScreen = StartMenu.Find("Login_Screen");
        string username = LoginScreen.Find("Username Fields").Find("Username").gameObject.GetComponent<TMP_InputField>().text;
        string password = ComputeSha512Hash(LoginScreen.Find("Password Fields").Find("Password").gameObject.GetComponent<TMP_InputField>().text);

        if(username != "" || password != "")
        {
            return  new string[] { username, password };
        }
        else
        {
            showError("Töltsön ki minden mezőt!");
            return new string[] {"ERROR"};
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string[] getRegistrationData()
    {
        Transform StartMenu = GameObject.Find("Start-Menu").transform;
        Transform RegisterScreen = StartMenu.Find("Register_Screen");
        string emailField = RegisterScreen.Find("Email Fields").Find("Email").gameObject.GetComponent<TMP_InputField>().text;
        string usernameField = RegisterScreen.Find("Username Fields").Find("Username").gameObject.GetComponent<TMP_InputField>().text;
        string passwordField = ComputeSha512Hash(RegisterScreen.Find("Password Fields").Find("Password").gameObject.GetComponent<TMP_InputField>().text);
        string password_confirmField = ComputeSha512Hash(RegisterScreen.Find("Password Confirm Fields").Find("Password_Confirm").gameObject.GetComponent<TMP_InputField>().text);

        if(emailField != "" && usernameField != "" && passwordField != "" && password_confirmField != "")
        {
            if(password_confirmField == passwordField)
            {
                return new string[] {emailField,usernameField, passwordField};
            }
            else
            {
                showError("A két jelszó nem egyezik!");
                return new string[] {"ERROR"};
            }
        }
        else
        {
            showError("Töltsön ki minden mezőt!");
            return new string[] {"ERROR"}; 
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="error"></param>
    public void showError(string error)
    {
        Transform StartMenu = GameObject.Find("Start-Menu").transform;
        Transform ErrorWindow = StartMenu.Find("Pop-Up_Window");
        ErrorWindow.gameObject.SetActive(true);
        ErrorWindow.Find("Error_MSG").gameObject.GetComponent<TextMeshProUGUI>().text = error;

    }


}
