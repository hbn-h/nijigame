using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Move : MonoBehaviour
{
    public float speed = 1000f;
    public float target_x;
    public float target_y;
    public static bool flag = false;
    // //以下回転用の変数
    // public Sprite omoteSprite;
    // public Sprite uraSprite;

    // Image myImage;


    // // Start is called before the first frame update
    // void Start()
    // {
    //     myImage = GetComponent<Image>();
    //     //Debug.Log("start");
    //     //StartCoroutine ("CardOpen");
    // }
    
    // public IEnumerator CardUp ()//カードの回転
    // {
    //     //Debug.Log("check");
    //     float Speed = 360f;
    //     float angle = -180f;

    //     //-90度を超えるまで回転
    //     while (angle < -90f)
    //     {
    //         angle += Speed * Time.deltaTime;
    //         transform.eulerAngles = new Vector3 (0, angle, 0);
    //         yield return null;
    //     }

    //     //画像差し替え
    //     myImage.sprite = omoteSprite;

    //     //0度まで回転
    //     while (angle < 0f)
    //     {
    //         angle += Speed * Time.deltaTime;
    //         transform.eulerAngles = new Vector3 (0, angle, 0);
    //         yield return null;
    //     }

    //     //綺麗に0度にならないことがあるため、補正
    //     transform.eulerAngles = new Vector3 (0, 0, 0);
    // }

    // public IEnumerator CardDown ()//カードの回転
    // {
    //     //Debug.Log("check");
    //     float Speed = 360f;
    //     float angle = 0f;

    //     //-90度を超えるまで回転
    //     while (angle > -90f)
    //     {
    //         angle -= Speed * Time.deltaTime;
    //         transform.eulerAngles = new Vector3 (0, angle, 0);
    //         yield return null;
    //     }

    //     //画像差し替え
    //     myImage.sprite = uraSprite;

    //     //0度まで回転
    //     while (angle > -180f)
    //     {
    //         angle -= Speed * Time.deltaTime;
    //         transform.eulerAngles = new Vector3 (0, angle, 0);
    //         yield return null;
    //     }

    //     //綺麗に0度にならないことがあるため、補正
    //     transform.eulerAngles = new Vector3 (0, -180, 0);
    // }


    void CheckChange()
    {
        GameInfo.check = true;
    }
    void TimerChange()
    {
        Timer.myTransform.localScale = new Vector3(2f, 0.06f, 1);
    }


    void Update()
    {
        if (GameInfo.moveflag)
        {
            //StartCoroutine("CardUp");
            Vector3 target = new Vector3(target_x, target_y, 0f);
            float step = speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, step);
        }
        else if (!GameInfo.moveflag)
        {
            if (flag)//CheckChangeを一度だけ起動するためのもの
            {
                Invoke("CheckChange", 0.7f);
                if (GameInfo.modeflag) {Invoke("TimerChange", 1.1f);}
                flag = false;
            }
            //StartCoroutine ("CardDown");
            Vector3 target = new Vector3(0f, -100f, 0f);
            float step = speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, step);

        }

    }


}
