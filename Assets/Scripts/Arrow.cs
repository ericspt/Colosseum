using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow
{
    public int id { get; set; }
    public int type { get; set; }
    public GameObject thisObj { get; set; }
    public bool deleted { get; set; }

    public Arrow()
    {
        id = declarations.numberOfArrows;
        type = 0;
        thisObj = null;
        deleted = false;
    }

}
