using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public static float speed;
    public static Transform myTransform;
    Vector3 scale;
    void Start()
    {
        speed = 0.4f;
    }

    void Update()
    {
        myTransform = this.transform;
        scale = myTransform.localScale;

        if (scale.x > 2.5){}
        else if (scale.x >= 0)
        {
            scale.x -= speed * Time.deltaTime;
            myTransform.localScale = scale;
        }
        else
        {
            ResultInfo.flag = 2;//scoremodeの終了
            SceneManager.LoadScene("Result");
        }
    }

}
