using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    GameObject volume;
    void Start()
    {    
       volume = GameObject.Find("Volume");
    }

    public void ToVolume()
    {
        volume.SetActive(true);
    }

    public void Close()
    {
        volume.SetActive(false);
    }
}
