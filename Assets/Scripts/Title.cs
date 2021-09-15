using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    bool flag;

    void Start()
    {
        flag = true;
    }

    void Update()
    {
        if (flag)
        {
            flag = false;
            GameObject.Find("explain").SetActive(false);
            GameObject.Find("Volume").SetActive(false);
        }
    }
}
