using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System.Security.Cryptography;
using UnityEngine.Networking;

public class login : MonoBehaviour {

    string LoginUserURL = "http://playcolosseum.com/login.php";
    
    public static UserM currentUser = new UserM();

    public void rememberCredentials()
    {
        if (declarations.toggle.isOn)
        {
            PlayerPrefs.SetString("username", declarations.usernameTextLogin.text);
            PlayerPrefs.SetString("password", declarations.passwordTextLogin.text);
        }
    }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown(KeyCode.Return) && scene.buildIndex == 0)
        {
            if (declarations.loginPanel.activeInHierarchy)
            {
                rememberCredentials();
                LoginTheUser();
            }
        }
    }
    public void Logout()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
    public void LogoutFromMenu()
    {
        PlayerPrefs.DeleteAll();
        declarations.successPanel.SetActive(true);
        declarations.successPanelText.text = "You logged out.";
    }

    public void LoginUserPrefs()
    {
        if (PlayerPrefs.HasKey("username"))
        { 
            string user = PlayerPrefs.GetString("username");
            string pass = PlayerPrefs.GetString("password");
            StartCoroutine(LoginUser(user, pass));
        }
        else
        {
            declarations.loginPanel.SetActive(true);
        }
    }

    public void LoginTheUser()
    {
        StartCoroutine(LoginUser(declarations.usernameTextLogin.text, declarations.passwordTextLogin.text));
    }

    public IEnumerator LoginUser(string user, string pass)
    {
        declarations.loadingPanel.SetActive(true);
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", user);
        form.AddField("passwordPost", ComputeSha256Hash(pass));
        UnityWebRequest wwwL = UnityWebRequest.Post(LoginUserURL, form);
        yield return wwwL.SendWebRequest();
        string www = Encoding.UTF8.GetString(wwwL.downloadHandler.data);

        if (www != "-2" && www != "-3")
        {
            yield return StartCoroutine(Camera.main.GetComponent<dataLoader>().loadDataIE());
            currentUser = dataLoader.usersM[Int32.Parse(www) - 1];
            if (currentUser.p_confemail == 0)
            {
                declarations.confEmailPanel.SetActive(true);
            } else if (currentUser.p_class == 0)
            {
                declarations.classPanel.SetActive(true);
            } else
            {
                SceneManager.LoadScene(1);
            }
        } else if (www == "-2")
        {
            declarations.errorPanel.SetActive(true);
            declarations.errorPanelText.text = "The password is incorrect.";
        } else if (www == "-3")
        {
            declarations.errorPanel.SetActive(true);
            declarations.errorPanelText.text = "The username does not exist.";
        }
        declarations.loadingPanel.SetActive(false);
    }

    static string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

}
