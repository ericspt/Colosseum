using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pSystem : MonoBehaviour
{

    public ParticleSystem pSys;

    public void startPSystem()
    {
        pSys.Play();
    }
    public void stopPSystem()
    {
        pSys.Stop();
    }
}
