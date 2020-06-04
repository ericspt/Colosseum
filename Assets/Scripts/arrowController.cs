using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * 200f * declarations.difficulty);
    }
}
