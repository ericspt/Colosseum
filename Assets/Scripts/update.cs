using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;

public class update : MonoBehaviour
{
    private void Start()
    {
        showUpdatePanel();
    }
    public void showUpdatePanel ()
    {
        StartCoroutine(showUpdatePanelIE());
    }
    public IEnumerator showUpdatePanelIE ()
    {
        string UpdateURL = "http://playcolosseum.com/version.txt";
        UnityWebRequest updateRequest = UnityWebRequest.Get(UpdateURL);
        yield return updateRequest.SendWebRequest();
        string webVersion = Encoding.UTF8.GetString(updateRequest.downloadHandler.data);
        if (webVersion != declarations.version)
        {
            declarations.updatePanel.SetActive(true);
        }
    }
}
