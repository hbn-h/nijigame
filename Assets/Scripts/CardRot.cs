using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardRot : MonoBehaviour
{
    public Sprite omoteSprite;

    Text myText;
    //ここからSound用の使い捨て
    public static float nowBGM = 0.3f;
    public static float nowSE = 0.3f;
    //ここまで

    void Start ()
    {
        GameObject.Find("rank").SetActive(false);
        //Debug.Log("start");
        StartCoroutine ("CardOpen");
    }

    //右回転用
    public IEnumerator CardOpen ()
    {
        //Debug.Log("check");
        float Speed = 360f;
        float angle = -180f;

        //-90度を超えるまで回転
        while (angle < -90f)
        {
            angle += Speed * Time.deltaTime;
            transform.eulerAngles = new Vector3 (0, angle, 0);
            yield return null;
        }

        //画像差し替え
        GameObject.Find("rank").SetActive(true);

        //0度まで回転
        while (angle < 0f)
        {
            angle += Speed * Time.deltaTime;
            transform.eulerAngles = new Vector3 (0, angle, 0);
            yield return null;
        }

        //綺麗に0度にならないことがあるため、補正
        transform.eulerAngles = new Vector3 (0, 0, 0);
    }
}
