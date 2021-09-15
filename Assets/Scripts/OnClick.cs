using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    public int number;
    Button button;
    Button button1; Button button2; Button button3; Button button4;
    Button button5; Button button6; Button button7; Button button8;
    Image color;

    void SpeedChange()
    {
        GameInfo.speedup_flag = false;
    }

    void MoveflagChange()
    {
        GameInfo.moveflag = false;
    }

    void SceneChange()
    {
        SceneManager.LoadScene("Result");
    }

    void ButtonEnabledChange()
    {
        button1.enabled = true; button2.enabled = true; button3.enabled = true; button4.enabled = true;
        button5.enabled = true; button6.enabled = true; button7.enabled = true; button8.enabled = true;
    }

    public void Onclick()
    {
        if(GameInfo.correct_1 == number-1 | GameInfo.correct_2 == number-1 | GameInfo.correct_3 == number-1)//正解のとき
        {
            SE_card.SE_flag = 1;

            button = GetComponent<Button>();
            color = GetComponent<Image>();
            button.enabled = false;//ボタン無効化
            color.color = Color.black;//ボタンの色を黒へ

            GameInfo.point += 1;
            GameInfo.count_correct_B += 1;

            if (!GameInfo.modeflag)//normalmodeのとき
            {
                if(GameInfo.count_correct_A == GameInfo.count_correct_B)
                {
                    button1 = GameObject.Find("card1").GetComponent<Button>(); button2 = GameObject.Find("card2").GetComponent<Button>();
                    button3 = GameObject.Find("card3").GetComponent<Button>(); button4 = GameObject.Find("card4").GetComponent<Button>();
                    button5 = GameObject.Find("card5").GetComponent<Button>(); button6 = GameObject.Find("card6").GetComponent<Button>();
                    button7 = GameObject.Find("card7").GetComponent<Button>(); button8 = GameObject.Find("card8").GetComponent<Button>();
                    button1.enabled = true; button2.enabled = true; button3.enabled = true; button4.enabled = true;
                    button5.enabled = true; button6.enabled = true; button7.enabled = true; button8.enabled = true;

                    Invoke("MoveflagChange", 0.25f);
                    Move.flag = true;
                }
            }

            else//scoremodeのとき
            {
                if (GameInfo.score < 400) {GameInfo.score += 100;}//500
                else if (GameInfo.score == 400) 
                {
                    GameInfo.speedup_flag = true;
                    Invoke("SpeedChange", 0.7f);
                    GameInfo.score += 100;
                    Timer.speed = 0.5f;
                }
                else if (GameInfo.score < 1300) {GameInfo.score += 200;}//1500
                else if (GameInfo.score == 1300) 
                {
                    GameInfo.speedup_flag = true;
                    Invoke("SpeedChange", 0.7f);
                    GameInfo.score += 200;
                    Timer.speed = 0.6f;
                }
                else if (GameInfo.score < 2700) {GameInfo.score += 300;}//3000
                else if (GameInfo.score == 2700) 
                {
                    GameInfo.speedup_flag = true;
                    Invoke("SpeedChange", 0.7f);
                    GameInfo.score += 300;
                    Timer.speed = 0.7f;
                }
                else if (GameInfo.score < 7500) {GameInfo.score += 500;}//8000
                else if (GameInfo.score == 7500) 
                {
                    GameInfo.speedup_flag = true;
                    Invoke("SpeedChange", 0.7f);
                    GameInfo.score += 500;
                    Timer.speed = 0.8f;
                }
                else {GameInfo.score += 500;}

                Timer.myTransform.localScale = new Vector3(3f, 0.06f, 1);//timerリセット(この時点ではtimerは動かない Moveから動かす)

                button1 = GameObject.Find("card1").GetComponent<Button>(); button2 = GameObject.Find("card2").GetComponent<Button>();
                button3 = GameObject.Find("card3").GetComponent<Button>(); button4 = GameObject.Find("card4").GetComponent<Button>();
                button5 = GameObject.Find("card5").GetComponent<Button>(); button6 = GameObject.Find("card6").GetComponent<Button>();
                button7 = GameObject.Find("card7").GetComponent<Button>(); button8 = GameObject.Find("card8").GetComponent<Button>();
                Invoke("ButtonEnabledChange", 1f);

                Invoke("MoveflagChange", 0.1f);
                Move.flag = true;
            }
        }
        else //不正解のとき
        {
            SE_card.SE_flag = 2;

            button = GetComponent<Button>();
            color = GetComponent<Image>();
            button.enabled = false;//ボタン無効化
            color.color = Color.black;//ボタンの色を黒へ

            if (!GameInfo.modeflag)//normalmodeのとき
            {
                if(GameInfo.life == 3)
                {
                    GameInfo.life -= 1;
                    GameObject heart_1;
                    heart_1 = GameObject.Find("heart1");
                    heart_1.GetComponent<Image>().color = Color.white;
                }
                else if(GameInfo.life == 2)
                {
                    GameInfo.life -= 1;
                    GameObject heart_2;
                    heart_2 = GameObject.Find("heart2");
                    heart_2.GetComponent<Image>().color = Color.white;
                }
                else if (GameInfo.life == 1)
                {
                    GameInfo.life -= 1;
                    GameObject heart_3;
                    heart_3 = GameObject.Find("heart3");
                    heart_3.GetComponent<Image>().color = Color.white;

                    ResultInfo.flag = 0;//nomalmodeのゲームオーバー
                    Invoke("SceneChange", 0.23f);
                    //Debug.Log("失敗");
                }
            }

            else//scoremodeのとき
            {
                ResultInfo.flag = 2;//scoremodeの終了
                    Invoke("SceneChange", 0.23f);
            }

        }

    }
}
