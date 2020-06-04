using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security.Cryptography;
using UnityEngine.Networking;

public class register : MonoBehaviour {

    string CreateUserURL = "http://playcolosseum.com/register.php";
    string SendConfEmailURL = "http://playcolosseum.com/sendConfEmail.php";

    private int tokenSent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && declarations.registerPanel.activeInHierarchy)
        {
            CreateTheUser();
        }
    }

    private void Start()
    {
        tokenSent = generateToken();
    }

    public void CreateTheUser ()
    {
        StartCoroutine(CreateUser());
    }

    public IEnumerator CreateUser()
    {
        if (IsValidEmail (declarations.emailTextRegister.text))
        { 
            declarations.loadingPanel.SetActive(true);
            WWWForm form = new WWWForm();
            form.AddField("usernamePost", declarations.usernameTextRegister.text);
            form.AddField("passwordPost", ComputeSha256Hash(declarations.passwordTextRegister.text));
            form.AddField("emailPost", declarations.emailTextRegister.text);
            form.AddField("tokenPost", tokenSent.ToString());

            UnityWebRequest www = UnityWebRequest.Post(CreateUserURL, form);
            yield return www.SendWebRequest();
            string temp = Encoding.UTF8.GetString(www.downloadHandler.data);

            if (temp.Contains("true"))
            {
                WWWForm form2 = new WWWForm();
                form2.AddField("emailPost", declarations.emailTextRegister.text);
                form2.AddField("tokenPost", tokenSent.ToString());
                UnityWebRequest www2 = UnityWebRequest.Post(SendConfEmailURL, form2);
                yield return www2.SendWebRequest();
                declarations.successPanel.SetActive(true);
                declarations.successPanelText.text = "You have successfully registered. An email has been sent to you to confirm it. Please follow its instructions.";
            }
            else if (temp.Contains("error1"))
            {
                declarations.errorPanel.SetActive(true);
                declarations.errorPanelText.text = "The username you picked is already in use.";
            }
            else
            {
                declarations.errorPanel.SetActive(true);
                declarations.errorPanelText.text = "The email you picked is already in use.";
            }
            declarations.loadingPanel.SetActive(false);
        }
        else
        {
            declarations.errorPanel.SetActive(true);
            declarations.errorPanelText.text = "The email you picked is not valid.";
        }
    }

    private int generateToken ()
    {
        return Random.Range(0, 100000);
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

    bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
