using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KanKikuchi.AudioManager;


public class Sound_Slider : MonoBehaviour
{
    //KanKikuchi.AudioManager

    Slider BGMSlider;
    Slider SESlider;
    float nowBGM;
    float nowSE;
 
    void Start()
    {
        BGMSlider = GameObject.Find("BGMVolume").GetComponent<Slider>();
        SESlider = GameObject.Find("SEVolume").GetComponent<Slider>();
        nowBGM = CardRot.nowBGM;
        nowSE = CardRot.nowSE;
 
        BGMSlider.value = nowBGM;
        SESlider.value = nowSE;
 
        //スライダーの現在値の設定
        
    }

    public void BGMVolume()
    {
        BGMManager.Instance.ChangeBaseVolume(BGMSlider.value);
        CardRot.nowBGM = BGMSlider.value;
    }

    public void SEVolume()
    {
        SEManager.Instance.ChangeBaseVolume(SESlider.value);
        CardRot.nowSE = SESlider.value;
    }


}
