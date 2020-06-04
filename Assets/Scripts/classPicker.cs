using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class classPicker : MonoBehaviour {

    string ClassPickerURL = "http://playcolosseum.com/class.php";

    public void PickTheClass(string classText)
    {
        StartCoroutine(PickClass(classText));
    }

    public IEnumerator PickClass(string classText)
    {
        declarations.loadingPanel.SetActive(true);
        WWWForm form = new WWWForm();
        form.AddField("idPost", login.currentUser.p_id);
        form.AddField("classPost", classText);
        login.currentUser.p_class = Int32.Parse(classText);
        UnityWebRequest wwwL = UnityWebRequest.Post(ClassPickerURL, form);
        yield return wwwL.SendWebRequest();
        declarations.loadingPanel.SetActive(false);
        
        SceneManager.LoadScene(1);
        
    }

}
