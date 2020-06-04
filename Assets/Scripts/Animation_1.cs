using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_1 : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator walkAndPunch(int player) // player = -1 = Enemy, player = 1 = Player
    {
        anim.SetBool("isWalking", true);
        yield return StartCoroutine(moveToPoint(transform, transform.position, transform.position + new Vector3(0f, 0f, player * 40f), 2f));
        anim.SetBool("isHitting", true);
        anim.SetBool("isWalking", false);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isWalking", true);
        anim.SetBool("isHitting", false);
        yield return StartCoroutine(rotate180());
        yield return StartCoroutine(moveToPoint(transform, transform.position, transform.position - new Vector3(0f, 0f, player * 40f), 2f));
        yield return StartCoroutine(rotate180());
        anim.SetBool("isWalking", false);
    }
    public IEnumerator getHit()
    {
        anim.SetBool("isHit", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isHit", false);
    }
    public IEnumerator attack(int weapon, int player)
    {
        // Spawn Gun
        GameObject weaponModel = Instantiate(declarations.items[weapon - 1].i_go, transform.position + new Vector3(4f, 4f, 0f), Quaternion.identity);
        // AK47
        if (weapon == 2)
        {
            weaponModel.transform.eulerAngles += new Vector3(0f, 270f, 0f);
            weaponModel.transform.localScale += new Vector3(1f, 1f, 4f);
            weaponModel.transform.position += new Vector3(1f, 2f, 0f);
            yield return StartCoroutine(Fire(false, 1f, Color.black, weaponModel.transform.position, transform.position + new Vector3(0f, 12f, player * 50f), 3, declarations.fightPrefabs[0]));
            yield return new WaitForSeconds(1f);
        }
        // Toxic Potion
        if (weapon == 4)
        {
            yield return StartCoroutine(moveToPoint(weaponModel.transform, weaponModel.transform.position, transform.position + new Vector3(0f, 12f, player * 50f), 1.2f));
        }
        Destroy(weaponModel);
    }
    public IEnumerator skill(string s_name)
    {
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator moveToPoint(Transform go, Vector3 from, Vector3 to, float moveDuration)
    {
        float t = 0.0f;
        while (t < moveDuration)
        {
            t += Time.deltaTime;
            go.transform.position = Vector3.Lerp(from, to, t / moveDuration);
            yield return null;
        }
    }
    public IEnumerator rotate180 ()
    {
        float t = 0.0f;
        Vector3 from = transform.eulerAngles;
        Vector3 target = transform.eulerAngles + new Vector3(0f, 180f, 0f);
        while (t < 1f)
        {
            t += Time.deltaTime;
            transform.eulerAngles = Vector3.Lerp(from, target, t / 1f);
            yield return null;
        }
    }

    // AK47
    public IEnumerator Fire(bool big, float speed, Color color, Vector3 from, Vector3 to, int numberOfBullets, GameObject bullet)
    {
        for (int i = 0; i < numberOfBullets; i ++)
        {
            GameObject aBullet = Instantiate(bullet, from, Quaternion.identity);
            aBullet.transform.eulerAngles += new Vector3(90f, 0f, 0f);
            aBullet.GetComponent<MeshRenderer>().material.color = color;
            if (big)
            {
                aBullet.transform.localScale += new Vector3(3f, 3f, 3f);
            }
            StartCoroutine(moveToPoint(aBullet.transform, from, to, 1f * speed));
            yield return new WaitForSeconds(0.2f);
        }
    }
}
