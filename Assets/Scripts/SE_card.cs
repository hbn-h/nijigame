using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class SE_card : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    public static int SE_flag = 0;

    void Update ()
    {
        if (SE_flag == 1) //正解
        {
            SE_flag = 0;        
            SEManager.Instance.Play(SEPath.DECISION40, 0.45f);
        }
        else if (SE_flag == 2) //不正解
        {
            SE_flag = 0;
            SEManager.Instance.Play(SEPath.CANCEL5, 0.35f);
        }
    }
}