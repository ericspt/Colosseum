using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.Networking;

public class confEmail : MonoBehaviour {

    string ConfirmEmailURL = "http://playcolosseum.com/confEmail.php";
    
    public InputField tokenText;

    public GameObject errorPanel;
    public Text errorPanelText;

    public GameObject classPanel;

    public void ConfirmTheEmail()
    {
        StartCoroutine(ConfirmEmail());
    }
    public IEnumerator ConfirmEmail ()
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", login.currentUser.p_id);
        form.AddField("tokenPost", tokenText.text);

        /*
        WWW www = new WWW(ConfirmEmailURL, form);
        yield return www;
        */

        UnityWebRequest wwwL = UnityWebRequest.Post(ConfirmEmailURL, form);
        yield return wwwL.SendWebRequest();
        string www = Encoding.UTF8.GetString(wwwL.downloadHandler.data);
        if (www != "0")
        {
            yield return StartCoroutine(Camera.main.GetComponent<dataLoader>().loadDataIE());
            login.currentUser = dataLoader.usersM[Int32.Parse (www) - 1];
            classPanel.SetActive(true);
        }
        else if (www == "0")
        {
            errorPanel.SetActive(true);
            errorPanelText.text = "The token is incorrect. Please check your email!";
        }
    }

}
