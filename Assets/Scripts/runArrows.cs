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
        updateScore();
    }

    public void updateScore()
    {
        declarations.scoreText.text = declarations.score.ToString();
        if (declarations.difficulty == 1)
        {
            declarations.scoreText.text += "/100";
        }
        else if (declarations.difficulty == 2)
        {
            declarations.scoreText.text += "/200";
        }
        else
        {
            declarations.scoreText.text += "/400";
        }
    }

    void Update()
    {
        float min = 1300f;
        bool arrowFound = false;
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
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
                updateScore();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
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
                updateScore();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
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
                updateScore();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
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
                updateScore();
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
                    updateScore();
                }
                if (declarations.arrowArray[i].id == min)
                {
                    Destroy(declarations.arrowArray[i].thisObj);
                    declarations.arrowArray[i].deleted = true;
                    int valueScore = scoring(declarations.arrowArray[i].thisObj.transform.position.y, gy, declarations.arrowArray[i].thisObj);
                    declarations.score += valueScore;
                    scoreText.text = "+ " + valueScore;
                    updateScore();
                }
            }
        }
    }

    public int scoring(float myY, float grayY, GameObject obj)
    {
        if (Math.Abs(myY - grayY) <= 30f)
        {
            GameObject neww = Instantiate(declarations.redAnim, obj.transform.position, Quaternion.identity, declarations.canvas.transform);
            return 5;
        }
        else if (Math.Abs(myY - grayY) <= 120f)
        {
            GameObject neww = Instantiate(declarations.yellowAnim, obj.transform.position, Quaternion.identity, declarations.canvas.transform);
            return 3;
        }
        else
        {
            GameObject neww = Instantiate(declarations.whiteAnim, obj.transform.position, Quaternion.identity, declarations.canvas.transform);
            return 1;
        }
    }
}
