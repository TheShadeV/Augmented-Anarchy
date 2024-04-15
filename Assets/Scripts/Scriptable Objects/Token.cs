using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Token", menuName = "Token")]
public class Token : ScriptableObject
{
    private int token;
    private int user_id;

    public void setToken(int token)
    {
        this.token = token;
    }

    public int getToken()
    {
        return token;
    }
    public void setUserId(int user_id)
    {
        this.user_id = user_id;
    }
    public int getUserId()
    {
        return user_id;
    }
}
