using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explain : MonoBehaviour
{
    int page;
    GameObject explain;
    GameObject main_explain; GameObject liver1; GameObject liver2; GameObject liver3;
    GameObject back; GameObject next; GameObject close;
    void Start()
    {
        explain = GameObject.Find("explain");

        main_explain = GameObject.Find("main_explain");
        liver1 = GameObject.Find("liver1");
        liver2 = GameObject.Find("liver2");
        liver3 = GameObject.Find("liver3");
        back = GameObject.Find("back");
        next = GameObject.Find("next");
        close = GameObject.Find("close");
    }

    public void Toexplain()
    {
        explain.SetActive(true);
        main_explain.SetActive(true);
        liver1.SetActive(false);
        liver2.SetActive(false);
        liver3.SetActive(false);
        back.SetActive(false);
        page = 0;
    }

    public void Close()
    {
        main_explain.SetActive(true);
        liver1.SetActive(true);
        liver2.SetActive(true);
        liver3.SetActive(true);
        back.SetActive(true);
        next.SetActive(true);

        explain.SetActive(false);
    }

    public void Back()
    {
        if(page == 3)//liver3の画面
        {
            liver3.SetActive(false);
            liver2.SetActive(true);
            page -= 1;
            next.SetActive(true);
        }        
        else if (page == 2)//liver2の画面
        {
            liver2.SetActive(false);
            liver1.SetActive(true);
            page -= 1;
        }
        else if (page == 1)//liver1の画面
        {
            liver1.SetActive(false);
            main_explain.SetActive(true);
            page -= 1;
            back.SetActive(false);
        }

    }
    public void Next()
    {
        if(page == 0)//main_explainの画面
        {
            main_explain.SetActive(false);
            liver1.SetActive(true);
            page += 1;
            back.SetActive(true);
        }
        else if (page == 1)//liver1の画面
        {
            liver1.SetActive(false);
            liver2.SetActive(true);
            page += 1;
        }
        else if (page == 2)//liver2の画面
        {
            liver2.SetActive(false);
            liver3.SetActive(true);
            next.SetActive(false);
            page += 1;
        }
    }
    void Update()
    {

    }
}
