using MySql.Data.MySqlClient;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class DatabaseManager : MonoBehaviour
{
    #region VARIABLES

    [Header("Database Properties")]
    public string Host = "localhost";
    public string User = "root";
    public string Password = "";
    public string Database = "augmentedanarchy";

    #endregion

    #region UNITY METHODS

    private void Start()
    {
        checkForUser();
    }

    #endregion

    #region METHODS

    private MySqlConnection Connect()
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        builder.Server = Host;
        builder.UserID = User;
        builder.Password = Password;
        builder.Database = Database;

        try
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ToString()))
            {
                connection.Open();
                print("MySQL - Opened Connection");
                return connection;
            }
        }
        catch (MySqlException exception)
        {
            Debug.Log("Szar");
            print(exception.Message);
            return null;

        }

    }

    private void checkForUser()
    {
        string name = "asd";
        string password = "1234";
        MySqlConnection connection = Connect();
        MySqlCommand command = new MySqlCommand("SELECT CASE WHEN EXISTS(SELECT nev, jelszo FROM users WHERE nev = '"+name+"' and jelszo = SHA2('"+password+"', '256')) THEN 'TRUE' ELSE 'FALSE' END AS 'isRegistered'", connection);
        MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
        dataAdapter.SelectCommand = command;
        DataTable table = new DataTable();
        dataAdapter.Fill(table);
        connection.Close();
        //Help me Debug.Log the Select result
        if (table.Rows[0][0].ToString() == "TRUE")
        {
            Debug.Log("User exists");
        }
        else
        {
            Debug.Log("User doesn't exist");
        }
        
        
        
    }

    #endregion
}