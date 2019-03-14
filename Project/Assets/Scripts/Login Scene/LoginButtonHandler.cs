
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Collections;


public class LoginButtonHandler : MonoBehaviour
{

    public InputField username;
    public InputField password;

    public void GameModesLoader(int sceneIndex)
    {
        //if (checkCredentials())
        playerEnter.playernamestr = username.text;
        SceneManager.LoadScene(sceneIndex);
    }

    public static Hashtable User_Pass_Hash()
    {
        Hashtable hTable = new Hashtable();
        hTable.Add("Patrick", "p");
        hTable.Add("Zack", "z");
        hTable.Add("Gavy", "g");
        hTable.Add("Woma", "w");
        hTable.Add("Emmanuel", "e");
        return hTable;
    }

    public Boolean checkCredentials()
    {
        Hashtable hTable = User_Pass_Hash();
        if (hTable.ContainsKey(username.text))
            if ((string)hTable[username.text] == (password.text))
                return true;

        return false;
    }
}
