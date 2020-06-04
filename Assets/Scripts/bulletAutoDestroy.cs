using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAutoDestroy : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(awake());
    }
    // Start is called before the first frame update
    public IEnumerator awake()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    
}
