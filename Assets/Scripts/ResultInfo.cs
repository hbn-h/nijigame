using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultInfo : MonoBehaviour
{
    public static int flag;
    public static Text rank;
    void Start()
    {
        if (flag == 0)//ノーマルのゲームオーバー
        {
            GameObject.Find("normal_0").SetActive(true);
            GameObject.Find("normal_1").SetActive(false);
            GameObject.Find("scoring").SetActive(false);
        }

        else if (flag == 1)//ノーマルのクリア
        {
            GameObject.Find("normal_0").SetActive(false);
            GameObject.Find("normal_1").SetActive(true);
            GameObject.Find("scoring").SetActive(false);
        }
        else if (flag == 2)//スコアモード
        {
            GameObject.Find("normal_0").SetActive(false);
            GameObject.Find("normal_1").SetActive(false);
            GameObject.Find("scoring").SetActive(true);

            Text lastscore = GameObject.Find("lastscore").GetComponent<Text>();
            rank = GameObject.Find("rank").GetComponent<Text>();
            Text comment = GameObject.Find("comment").GetComponent<Text>();
            lastscore.text = "スコア：" + GameInfo.score.ToString();

            if (GameInfo.score <= 500)
            {
                rank.text = "D";
                //comment.text = "ノーマルモードで知識をつけてから\n再挑戦だ！";
                comment.text = "Fight!";
            }
            else if (GameInfo.score <= 3000)
            {
                rank.text = "C";
                //comment.text = "まだまだ先は長い\n時間をかけて覚えていこう！";
                comment.text = "Nice!";
            }
            else if (GameInfo.score <= 8000)
            {
                rank.text = "B";
                //comment.text = "ここまで安定して来られれば知識は十分！\nここからは反射神経との勝負…！";
                comment.text = "Good!";
            }
            else if (GameInfo.score <= 13000)
            {
                rank.text = "A";
                //comment.text = "ここから先は運も求められる！\n最高ランクまであと一歩！";
                comment.text = "Great!";
            }
            else
            {
                rank.text = "S";
                //comment.text = "最高ランクおめでとう！！！\nこれからもにじさんじを\n箱推ししていきましょう！";
                comment.text = "<color=yellow>Excellent!</color>";
            }

        }
    }
}
