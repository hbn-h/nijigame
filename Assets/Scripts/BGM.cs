using UnityEngine;
using System.Collections;
using KanKikuchi.AudioManager;
public class BGM: MonoBehaviour
{
    void Start()
    {

    }

    void Update() 
    {
        if (!BGMManager.Instance.IsPlaying())
        {
            BGMManager.Instance.Play(BGMPath.PASTEL_PLANET, 0.3f);
        }
        
    }
}
