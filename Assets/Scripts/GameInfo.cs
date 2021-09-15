using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using KanKikuchi.AudioManager;

// public static class ListExt
// {
//     public static T PopRandomElement<T>( this List<T> self )
//     {
//         var item = self[ Random.Range( 0, self.Count ) ];
//         self.Remove( item );
//         return item;
//     }
// }

public class GameInfo : MonoBehaviour
{
    public static bool modeflag;//モードの判定 true:scoremode false:normalmode

    float step_time;
    public int num;
    bool num_restflag;
    public static bool moveflag;//カードを動かすかどうかの判定
    public static bool rotflag;
    public static bool check;//カードを配るかどうかの判定
    public static bool speedup_flag;//speedupの表示
    GameObject speedup;

    public static int count_correct_A = 0;//１問クリアに必要な回答数
    public static int count_correct_B = 0;//ボタンのほうでの回答数の確認用
    public static int point;//合計で何人を正解できたか
    public static int score;//scoremodeの点数
    Text score_text;
    Text num_rest;
    Text num_rest_all;
    public static int life;//ミスしていい回数
    public static int correct_1 = 10; public static int correct_2 = 10; public static int correct_3 = 10;
    static List<List<string>> synclist;
    static List<List<string>> nsynclist;

    private Text name1; private Text name2; private Text name3; private Text name4;
    private Text name5; private Text name6; private Text name7; private Text name8;
    private Image color1; private Image color2; private Image color3; private Image color4;
    private Image color5; private Image color6; private Image color7; private Image color8;

    List<List<string>> chosen_mem;

    //List<List<string>> temp_synclist = synclist;
    //List<List<string>> temp_nsynclist = nsynclist;
    int synclist_count;
    
    public void Shuffle(int n, List<List<string>> deck) // シャッフルする
    {
        // nはlistの要素数
    
        // nが1より小さくなるまで繰り返す
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n+1);
    
            // k番目のカードをtempに代入
            List<string> temp = deck[k];
            deck[k] = deck[n];
            deck[n] = temp;
        }
    }

    void Start()
    {
        step_time = 0f;
        num_restflag = false;
        moveflag = false;
        check = true;
        speedup_flag = false;
        point = 0;
        score = 0;
        life = 3;

        chosen_mem = new List<List<string>>()
        {
            new List<string>() {"a", "#"}, new List<string>() {"b", "#"}, new List<string>() {"c", "#"}, new List<string>() {"d", "#"},
            new List<string>() {"e", "#"}, new List<string>() {"f", "#"}, new List<string>() {"g", "#"}, new List<string>() {"h", "#"},
        };

        if (!modeflag)
        {
            synclist = LiverInfo.synclist;
            nsynclist = LiverInfo.nsynclist;
            Shuffle(synclist.Count, synclist);
            Shuffle(nsynclist.Count, nsynclist);

            synclist_count = synclist.Count;

            Text selectname = GameObject.Find("Hint").GetComponent<Text>();
            selectname.text = "<size=20>選択中：</size>" + LiverInfo.selectName;
            
            num_rest = GameObject.Find("num_rest").GetComponent<Text>();
            num_rest_all = GameObject.Find("num_rest_all").GetComponent<Text>();
        }  
        else
        {
            score_text = GameObject.Find("score").GetComponent<Text>();
            speedup = GameObject.Find("speedup");

        }

        name1 = GameObject.Find("livername1").GetComponent<Text>(); name2 = GameObject.Find("livername2").GetComponent<Text>();
        name3 = GameObject.Find("livername3").GetComponent<Text>(); name4 = GameObject.Find("livername4").GetComponent<Text>();
        name5 = GameObject.Find("livername5").GetComponent<Text>(); name6 = GameObject.Find("livername6").GetComponent<Text>();
        name7 = GameObject.Find("livername7").GetComponent<Text>(); name8 = GameObject.Find("livername8").GetComponent<Text>();

        color1 = GameObject.Find("card1").GetComponent<Image>(); color2 = GameObject.Find("card2").GetComponent<Image>();
        color3 = GameObject.Find("card3").GetComponent<Image>(); color4 = GameObject.Find("card4").GetComponent<Image>();
        color5 = GameObject.Find("card5").GetComponent<Image>(); color6 = GameObject.Find("card6").GetComponent<Image>();
        color7 = GameObject.Find("card7").GetComponent<Image>(); color8 = GameObject.Find("card8").GetComponent<Image>();

    }

    void ColorChange()
    {
        Color newcolor = default(Color);
        ColorUtility.TryParseHtmlString(chosen_mem[0][1], out newcolor);
        color1.color = newcolor;
        ColorUtility.TryParseHtmlString(chosen_mem[1][1], out newcolor);
        color2.color = newcolor;
        ColorUtility.TryParseHtmlString(chosen_mem[2][1], out newcolor);
        color3.color = newcolor;
        ColorUtility.TryParseHtmlString(chosen_mem[3][1], out newcolor);
        color4.color = newcolor;
        ColorUtility.TryParseHtmlString(chosen_mem[4][1], out newcolor);
        color5.color = newcolor;
        ColorUtility.TryParseHtmlString(chosen_mem[5][1], out newcolor);
        color6.color = newcolor;
        ColorUtility.TryParseHtmlString(chosen_mem[6][1], out newcolor);
        color7.color = newcolor;
        ColorUtility.TryParseHtmlString(chosen_mem[7][1], out newcolor);
        color8.color = newcolor;

    }

    void FontSizeChange(Text name)
    {
        if (name.text.Length >= 9)
        {
            name.fontSize = 20;
            name.text = name.text.Replace("・", "・\n");
        }        
        else if (name.text.Length >= 7)
        {
            name.fontSize = 23;

            if (name.text.ToString() == "えま★おうがすと")
            {
                name.text = name.text.Replace("★", "★\n");
            }
            else if (name.text.ToString() == "ギルザレンⅢ世")
            {
                name.text = name.text.Replace("ン", "ン\n");
            }
            else 
            {
                name.text = name.text.Replace("・", "・\n");
            }
        }
        else if (name.text.Length == 6) {name.fontSize = 20;}
        else if (name.text.Length >= 4) {name.fontSize = 23;}
        else{name.fontSize = 26;}
    }



    void Deal(int n)
    {
        count_correct_B = 0;
        num_restflag = true;
        //ランダムに選んだ８人in nsynclist をchosen_mem　に代入
        for(int i = 0; i < 8; i++)
        {
            chosen_mem[i] = nsynclist[i];
        }
        nsynclist.RemoveRange(0,7);

        Shuffle(8, chosen_mem);

        if (n == 1) //正解１枚
        {
            count_correct_A = 1;

            correct_1 = Random.Range(0,8);
            chosen_mem[correct_1] = synclist[0];

        }
        else if (n == 2) //正解２枚
        {
            count_correct_A = 2;

            correct_1 = Random.Range(0,8);
            correct_2 = Random.Range(0,8);

            while(correct_1 == correct_2)
            {
                correct_2 = Random.Range(0,8);
            }

            chosen_mem[correct_1] = synclist[0];
            chosen_mem[correct_2] = synclist[1];

        }
        else if (n == 3) //正解３枚
        {
            count_correct_A = 3;

            correct_1 = Random.Range(0,8);
            correct_2 = Random.Range(0,8);
            correct_3 = Random.Range(0,8);

            while(correct_1 == correct_2 | correct_2 == correct_3 | correct_3 == correct_1)
            {
                correct_2 = Random.Range(0,8);
                correct_3 = Random.Range(0,8);
            }

            chosen_mem[correct_1] = synclist[0];
            chosen_mem[correct_2] = synclist[1];
            chosen_mem[correct_3] = synclist[2];

        }
        
        name1.text = chosen_mem[0][0]; name2.text = chosen_mem[1][0]; name3.text = chosen_mem[2][0]; name4.text = chosen_mem[3][0];
        name5.text = chosen_mem[4][0]; name6.text = chosen_mem[5][0]; name7.text = chosen_mem[6][0]; name8.text = chosen_mem[7][0];

        FontSizeChange(name1); FontSizeChange(name2); FontSizeChange(name3); FontSizeChange(name4); 
        FontSizeChange(name5); FontSizeChange(name6); FontSizeChange(name7); FontSizeChange(name8);


        ColorChange();
        moveflag = true;

    }

    void Deal_score()
    {
        for(int i = 0; i < 8; i++)
        {
            chosen_mem[i] = nsynclist[i];
        }

        Shuffle(8, chosen_mem);

        correct_1 = Random.Range(0,8);
        //Debug.Log(correct_1+1);//答え
        chosen_mem[correct_1] = synclist[0];

        name1.text = chosen_mem[0][0]; name2.text = chosen_mem[1][0]; name3.text = chosen_mem[2][0]; name4.text = chosen_mem[3][0];
        name5.text = chosen_mem[4][0]; name6.text = chosen_mem[5][0]; name7.text = chosen_mem[6][0]; name8.text = chosen_mem[7][0];

        FontSizeChange(name1); FontSizeChange(name2); FontSizeChange(name3); FontSizeChange(name4);
        FontSizeChange(name5); FontSizeChange(name6); FontSizeChange(name7); FontSizeChange(name8);

        ColorChange();
        moveflag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!modeflag)//normalmodeのとき
        {
            num_rest.text = (count_correct_A - count_correct_B).ToString();
            num_rest_all.text = (synclist_count - point).ToString();

            //Debug.Log(check);
            if (synclist.Count == 0)
            {
                step_time += Time.deltaTime;
    
                // 1秒後に画面遷移
                if (step_time >= 1.0f)
                {
                    ResultInfo.flag = 1;//normalmodeのクリア
                    SceneManager.LoadScene("Result");
                }

            }
            else if (check)
            {
                correct_1 = 10; correct_2 = 10; correct_3 = 10;
                check = false;
                //残りの同期数で場合分け
                if (synclist.Count == 1 | synclist.Count == 2 | synclist.Count == 3) {num = 1;}
                else if (synclist.Count == 4 | synclist.Count == 5 | synclist.Count == 6) {num = 2;}
                else if (synclist.Count == 7 | synclist.Count == 9 | synclist.Count == 12) {num = 3;}
                else {Debug.Log("GameInfoのUpdateでバグ");}
                Deal(num);
            }

            if (count_correct_A == count_correct_B && num_restflag)
            {
                for (int i = 0; i < num; i++)
                {
                    synclist.Remove(synclist[0]);
                }
                num_restflag = false;
                //Debug.Log("synclistの一部削除");
                //Debug.Log(synclist.Count);
            }
        }

        else//scoremodeのとき
        {
            speedup.SetActive(speedup_flag);//speedupの表示
            if (!SEManager.Instance.GetCurrentAudioNames().Contains("decision24") && speedup_flag)
            {
                SEManager.Instance.Play(SEPath.DECISION24, 0.2f);
            }
            

            score_text.text = "スコア：" + score.ToString();

            if (check)
            {
                correct_1 = 10; correct_2 = 10; correct_3 = 10;
                check = false;
                int num = Random.Range(0, LiverInfo.liversinfo.Count);
                string selectName = LiverInfo.names[num];
                Text selectname = GameObject.Find("Hint").GetComponent<Text>();//scoremodeはここで色々決めるのでライバー選択、表示はここ
                selectname.text = "<size=20>選択中：</size>" + selectName;
                string sync = LiverInfo.liversinfo[selectName][0];
                var temp = LiverInfo.liversinfo[selectName];
                LiverInfo.liversinfo.Remove(selectName);

                synclist = new List<List<string>>();
                nsynclist = new List<List<string>>();

                foreach (KeyValuePair<string, List<string>> kvp in LiverInfo.liversinfo)
                {
                    if (kvp.Value[0] == sync)
                    {
                        //Debug.Log(kvp.Key);
                        synclist.Add(new List<string>() {kvp.Key, kvp.Value[1]});
                        //Debug.Log("true added");
                    }
                    else
                    {
                        nsynclist.Add(new List<string>() {kvp.Key, kvp.Value[1]});
                        //Debug.Log("false added");
                    }
                }
                LiverInfo.liversinfo.Add(selectName, temp);
                Shuffle(synclist.Count, synclist);
                Shuffle(nsynclist.Count, nsynclist);
                Deal_score();
            }
        }
    }
}
