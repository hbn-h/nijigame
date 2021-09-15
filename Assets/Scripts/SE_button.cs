using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

public class SE_button : MonoBehaviour
{
    public void OnSE_positive()
    {
        SEManager.Instance.Play(SEPath.DECISION42, 0.24f);
    }
    public void OnSE_negative()
    {
        SEManager.Instance.Play(SEPath.CANCEL2, 0.2f);
    }
}
