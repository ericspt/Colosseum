using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class runArrows : MonoBehaviour
{
    float gy;
    public Text scoreText;

    void Start()
    {
        gy = declarations.grayArrows[0].transform.position.y;
    }

    void Update()
    {
        float min = 1300f;
        bool arrowFound = false;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            for (int i = 0; i < declarations.numberOfArrows; i++)
            {
                if (declarations.arrowArray[i].deleted == false)
                {
                    if (min > Math.Abs(declarations.arrowArray[i].thisObj.transform.position.y - gy) && declarations.arrowArray[i].type == 0)
                    {
                        min = declarations.arrowArray[i].id;
                        arrowFound = true;
                    }
                }
            }
            if (arrowFound == false)
            {
                declarations.score -= 5;
                scoreText.text = "- 5";
                declarations.scoreText.text = declarations.score.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            for (int i = 0; i < declarations.numberOfArrows; i++)
            {
                if (declarations.arrowArray[i].deleted == false)
                {
                    if (min > Math.Abs(declarations.arrowArray[i].thisObj.transform.position.y - gy) && declarations.arrowArray[i].type == 1)
                    {
                        min = declarations.arrowArray[i].id;
                        arrowFound = true;
                    }
                }
            }
            if (arrowFound == false)
            {
                declarations.score -= 5;
                scoreText.text = "- 5";
                declarations.scoreText.text = declarations.score.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            for (int i = 0; i < declarations.numberOfArrows; i++)
            {
                if (declarations.arrowArray[i].deleted == false)
                {
                    if (min > Math.Abs(declarations.arrowArray[i].thisObj.transform.position.y - gy) && declarations.arrowArray[i].type == 2)
                    {
                        min = declarations.arrowArray[i].id;
                        arrowFound = true;
                    }
                }
            }
            if (arrowFound == false)
            {
                declarations.score -= 5;
                scoreText.text = "- 5";
                declarations.scoreText.text = declarations.score.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for (int i = 0; i < declarations.numberOfArrows; i++)
            {
                if (declarations.arrowArray[i].deleted == false)
                {
                    if (min > Math.Abs(declarations.arrowArray[i].thisObj.transform.position.y - gy) && declarations.arrowArray[i].type == 3)
                    {
                        min = declarations.arrowArray[i].id;
                        arrowFound = true;

                    }
                }
            }
            if (arrowFound == false)
            {
                declarations.score -= 5;
                scoreText.text = "- 5";
                declarations.scoreText.text = declarations.score.ToString();
            }
        }
        for (int i = 0; i < declarations.numberOfArrows; i++)
        {
            if (declarations.arrowArray[i].deleted == false)
            {
                if (declarations.arrowArray[i].thisObj.transform.position.y <= 0f)
                {
                    Destroy(declarations.arrowArray[i].thisObj);
                    declarations.arrowArray[i].deleted = true;
                    declarations.score -= 3;
                    scoreText.text = "- 3";
                    declarations.scoreText.text = declarations.score.ToString();
                }
                if (declarations.arrowArray[i].id == min)
                {
                    Destroy(declarations.arrowArray[i].thisObj);
                    declarations.arrowArray[i].deleted = true;
                    declarations.score += scoring(declarations.arrowArray[i].thisObj.transform.position.y, gy);
                    scoreText.text = "+ " + scoring(declarations.arrowArray[i].thisObj.transform.position.y, gy);
                    declarations.scoreText.text = declarations.score.ToString();
                }
            }
        }
    }

    public int scoring(float myY, float grayY)
    {
        if (Math.Abs(myY - grayY) <= 20f)
        {
            return 5;
        }
        else if (Math.Abs(myY - grayY) <= 120f)
        {
            return 3;
        }
        else
        {
            return 1;
        }
    }
}
