using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopPageManagement : MonoBehaviour
{

    private void deactivateAllPages ()
    {
        for (int i = 0; i < declarations.categorySizes[0]; i ++)
        {
            declarations.shopPages1[i].SetActive(false);
        }
        for (int i = 0; i < declarations.categorySizes[1]; i++)
        {
            declarations.shopPages2[i].SetActive(false);
        }
        for (int i = 0; i < declarations.categorySizes[2]; i++)
        {
            declarations.shopPages3[i].SetActive(false);
        }
        for (int i = 0; i < declarations.categorySizes[3]; i++)
        {
            declarations.shopPages4[i].SetActive(false);
        }
    }
    public void changeCategory (int category)
    {
        declarations.currentCategory = category;
        declarations.currentPage = 0;
        deactivateAllPages();
        if (category == 1)
        {
            declarations.shopPages1[0].SetActive(true);
        }
        if (category == 2)
        {
            declarations.shopPages2[0].SetActive(true);
        }
        if (category == 3)
        {
            declarations.shopPages3[0].SetActive(true);
        }
        if (category == 4)
        {
            declarations.shopPages4[0].SetActive(true);
        }
    }
    public void changePageRight ()
    {
        if (declarations.currentPage < declarations.categorySizes[declarations.currentCategory - 1] - 1)
        {
            if (declarations.currentCategory == 1)
            {
                declarations.shopPages1[declarations.currentPage].SetActive(false);
                declarations.shopPages1[declarations.currentPage + 1].SetActive(true);
            }
            else if (declarations.currentCategory == 2)
            {
                declarations.shopPages2[declarations.currentPage].SetActive(false);
                declarations.shopPages2[declarations.currentPage + 1].SetActive(true);
            }
            else if (declarations.currentCategory == 3)
            {
                declarations.shopPages3[declarations.currentPage].SetActive(false);
                declarations.shopPages3[declarations.currentPage + 1].SetActive(true);
            }
            else if (declarations.currentCategory == 4)
            {
                declarations.shopPages4[declarations.currentPage].SetActive(false);
                declarations.shopPages4[declarations.currentPage + 1].SetActive(true);
            }
            declarations.currentPage++;
        }
    }
    public void changePageLeft()
    {
        if (declarations.currentPage > 0)
        {
            if (declarations.currentCategory == 1)
            {
                declarations.shopPages1[declarations.currentPage].SetActive(false);
                declarations.shopPages1[declarations.currentPage - 1].SetActive(true);
            }
            else if (declarations.currentCategory == 2)
            {
                declarations.shopPages2[declarations.currentPage].SetActive(false);
                declarations.shopPages2[declarations.currentPage - 1].SetActive(true);
            }
            else if (declarations.currentCategory == 3)
            {
                declarations.shopPages3[declarations.currentPage].SetActive(false);
                declarations.shopPages3[declarations.currentPage - 1].SetActive(true);
            }
            else if (declarations.currentCategory == 4)
            {
                declarations.shopPages4[declarations.currentPage].SetActive(false);
                declarations.shopPages4[declarations.currentPage - 1].SetActive(true);
            }
            declarations.currentPage--;
        }
    }
}
