using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class spawnInfoPanel : MonoBehaviour
{
    GameObject instantiatedPanel;

    public void spawnPanel(string text)
    {
        //public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        if (instantiatedPanel == null)
        {
            instantiatedPanel = Instantiate(declarations.infoHover, new Vector2(Input.mousePosition.x + 100f, Input.mousePosition.y + 20f), Quaternion.identity, declarations.canvas.transform);
            instantiatedPanel.GetComponentInChildren<Text>().text = text;
        }
    }
    public void destroyPanel()
    {
        Destroy(instantiatedPanel);
    }
}
