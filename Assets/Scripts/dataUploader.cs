using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class dataUploader : MonoBehaviour {

    string DataUploaderURL = "http://playcolosseum.com/dataUploader.php";
    string ItemsUploaderURL = "http://playcolosseum.com/itemsUploader.php";

    public GameObject thisGO;

    public void uploadTheData ()
    {
        thisGO.SetActive(true);
        StartCoroutine(uploadTheDataIE());
        StartCoroutine(uploadTheItemsIE());
        thisGO.SetActive(false);
    }

    public IEnumerator uploadTheDataIE()
    {
        WWWForm form = new WWWForm();
        form.AddField("idPost", login.currentUser.p_id);
        form.AddField("namePost", login.currentUser.p_name);
        form.AddField("xpPost", login.currentUser.p_xp);
        form.AddField("atkPost", login.currentUser.p_atk.ToString());
        form.AddField("defPost", login.currentUser.p_def.ToString());
        form.AddField("cashPost", login.currentUser.p_cash);
        form.AddField("playedPost", login.currentUser.p_played);
        form.AddField("wonPost", login.currentUser.p_won);
        form.AddField("emailPost", login.currentUser.p_email);
        form.AddField("confEmailPost", login.currentUser.p_confemail);
        form.AddField("tokenPost", login.currentUser.p_token);
        form.AddField("classPost", login.currentUser.p_class);
        form.AddField("equippedWeaponPost", login.currentUser.p_eqw);
        form.AddField("equippedArmorPost", login.currentUser.p_eqa);
        form.AddField("equippedMedallionPost", login.currentUser.p_eqm);
        form.AddField("knownSkillsPost", login.currentUser.p_knownSkills);
        UnityWebRequest wwwL = UnityWebRequest.Post(DataUploaderURL, form);
        yield return wwwL.SendWebRequest();
    }

    public IEnumerator uploadTheItemsIE()
    {
        WWWForm form2 = new WWWForm();
        form2.AddField("idPost", login.currentUser.p_id);
        form2.AddField("item1Post", login.currentUser.p_item1);
        form2.AddField("item2Post", login.currentUser.p_item2);
        form2.AddField("item3Post", login.currentUser.p_item3);
        form2.AddField("item4Post", login.currentUser.p_item4);
        form2.AddField("item5Post", login.currentUser.p_item5);
        form2.AddField("item6Post", login.currentUser.p_item6);
        form2.AddField("item7Post", login.currentUser.p_item7);
        form2.AddField("item8Post", login.currentUser.p_item8);
        form2.AddField("item9Post", login.currentUser.p_item9);
        form2.AddField("item10Post", login.currentUser.p_item10);
        form2.AddField("item11Post", login.currentUser.p_item11);
        form2.AddField("item12Post", login.currentUser.p_item12);
        UnityWebRequest www2 = UnityWebRequest.Post(ItemsUploaderURL, form2);
        yield return www2.SendWebRequest();
    }

}
