using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LiverInfo : MonoBehaviour
{
    public static string selectName; //ゲーム画面に表示する用の名前
    public static List<List<string>> synclist;
    public static List<List<string>> nsynclist;
    
    //ライバー全員の情報を入れる
    public static Dictionary<string, List<string>> liversinfo;
    int num_livers;

    public static List<string> names;

    void Start()
    {
        liversinfo = new Dictionary<string, List<string>>()         //7文字以上で・がつかない人がいたら注意
        {
            //テンプレ　{"", new List<string>(){"", ""}},
            {"月ノ美兎", new List<string>(){"1期生", "#E43F3B"}},
            {"勇気ちひろ", new List<string>(){"1期生", "#7BB3EE"}},
            {"える", new List<string>(){"1期生", "#E2364F"}},
            {"樋口楓", new List<string>(){"1期生", "#FBAF71"}},
            {"静凛", new List<string>(){"1期生", "#745399"}},
            {"渋谷ハジメ", new List<string>(){"1期生", "#D7FAD7"}},
            {"鈴谷アキ", new List<string>(){"1期生", "#F2F9C3"}},
            {"モイラ", new List<string>(){"1期生", "#91ABD0"}},

            {"鈴鹿詩子", new List<string>(){"2期生", "#FA4F62"}},
            {"宇志海いちご", new List<string>(){"2期生", "#FFCACE"}},
            {"家長むぎ", new List<string>(){"2期生", "#FF899D"}},
            {"夕陽リリ", new List<string>(){"2期生", "#BFFFFF"}},
            {"物述有栖", new List<string>(){"2期生", "#81D4E2"}},
            {"文野環", new List<string>(){"2期生", "#EBDDB4"}},
            {"伏見ガク", new List<string>(){"2期生", "#FFCB5B"}},
            {"ギルザレンⅢ世", new List<string>(){"2期生", "#002FA7"}},
            {"剣持刀也", new List<string>(){"2期生", "#A590AF"}},
            {"森中花咲", new List<string>(){"2期生", "#C8F39A"}},

            {"叶", new List<string>(){"ゲマズ1期", "#ABD3D8"}},
            {"赤羽葉子", new List<string>(){"ゲマズ1期", "#CA636C"}},

            {"ドーラ", new List<string>(){"SEEDs1期生", "#A83E4A"}},
            {"海夜叉神", new List<string>(){"SEEDs1期生", "#7DC5ED"}},          ///
            {"名伽尾アズマ", new List<string>(){"SEEDs1期生", "#F7A57D"}},      ///
            {"出雲霞", new List<string>(){"SEEDs1期生", "#A9D6E3"}},            ///
            {"轟京子", new List<string>(){"SEEDs1期生", "#F8A69A"}},
            {"シスター・クレア", new List<string>(){"SEEDs1期生", "#DFC6A8"}},
            {"花畑チャイカ", new List<string>(){"SEEDs1期生", "#40CF84"}},
            {"社築", new List<string>(){"SEEDs1期生", "#B6C6F2"}},
            {"安土桃", new List<string>(){"SEEDs1期生", "#F295CE"}},
            {"鈴木勝", new List<string>(){"SEEDs1期生", "#7B788A"}},
            {"緑仙", new List<string>(){"SEEDs1期生", "#5DCCAB"}},
            {"卯月コウ", new List<string>(){"SEEDs1期生", "#F9E97A"}},
            {"八朔ゆず", new List<string>(){"SEEDs1期生", "#FCCA4D"}},          ///

            {"笹木咲", new List<string>(){"ゲマズ2期", "#EF9AAF"}},
            {"闇夜乃モルル", new List<string>(){"ゲマズ2期", "#EC4676"}},       ///
            {"本間ひまわり", new List<string>(){"ゲマズ2期", "#FBE340"}},

            {"魔界のりりむ", new List<string>(){"ゲマズ3期", "#D44968"}},
            {"葛葉", new List<string>(){"ゲマズ3期", "#ACA7BB"}},
            {"雪汝", new List<string>(){"ゲマズ3期", "#85AFE9"}},               ///
            {"椎名唯華", new List<string>(){"ゲマズ3期", "#F1C8DE"}},

            {"神田笑一", new List<string>(){"SEEDs2期生_1", "#F4D35B"}},
            {"鳴門こがね", new List<string>(){"SEEDs2期生_1", "#808080"}},//カラーコード明記なしのため灰色
            {"飛鳥ひな", new List<string>(){"SEEDs2期生_1", "#FAD8DC"}},
            {"春崎エアル", new List<string>(){"SEEDs2期生_1", "#4B5F9E"}},
            {"雨森小夜", new List<string>(){"SEEDs2期生_1", "#756F7D"}},
            {"鷹宮リオン", new List<string>(){"SEEDs2期生_1", "#CC3D7B"}},
            {"舞元啓介", new List<string>(){"SEEDs2期生_1", "#094078"}},

            {"竜胆尊", new List<string>(){"SEEDs2期生_2", "#745BFF"}},
            {"でびでび・でびる", new List<string>(){"SEEDs2期生_2", "#444C7D"}},
            {"桜凛月", new List<string>(){"SEEDs2期生_2", "#C57FC7"}},
            {"町田ちま", new List<string>(){"SEEDs2期生_2", "#EDDDBB"}},
            {"月見しずく", new List<string>(){"SEEDs2期生_2", "#E354AF"}},        ///
            {"ジョー・力一", new List<string>(){"SEEDs2期生_2", "#D598DD"}},
            {"遠北千南", new List<string>(){"SEEDs2期生_2", "#FCC5DC"}},          ///

            {"成瀬鳴", new List<string>(){"SEEDs2期生_3", "#E06489"}},
            {"ベルモンド・バンデラス", new List<string>(){"SEEDs2期生_3", "#683D46"}},
            {"矢車りね", new List<string>(){"SEEDs2期生_3", "#FEECD8"}},
            {"夢追翔", new List<string>(){"SEEDs2期生_3", "#AC324B"}},
            {"黒井しば", new List<string>(){"SEEDs2期生_3", "#585C82"}},

            {"童田明治", new List<string>(){"紅白アホ合戦", "#E34E4F"}},
            {"久遠千歳", new List<string>(){"紅白アホ合戦", "#FBD5F1"}},           ///

            {"郡道美玲", new List<string>(){"みれロア", "#A20063"}},
            {"夢月ロア", new List<string>(){"みれロア", "#D8368D"}},

            {"小野町春香", new List<string>(){"はるみや語部", "#FF336E"}},
            {"語部紡", new List<string>(){"はるみや語部", "#07A4E3"}},
            {"瀬戸美夜子", new List<string>(){"はるみや語部", "#C4FF2B"}},

            //{"御伽原江良", new List<string>(){"", "#FFBE5C"}},

            {"戌亥とこ", new List<string>(){"さんばか", "#9D3757"}},
            {"アンジュ・カトリーナ", new List<string>(){"さんばか", "#C83C35"}},
            {"リゼ・ヘルエスタ", new List<string>(){"さんばか", "#42FFFF"}},

            {"三枝明那", new List<string>(){"紅ズワイガニ", "#392D47"}},
            {"愛園愛美", new List<string>(){"紅ズワイガニ", "#F98FB7"}},
            
            {"鈴原るる", new List<string>(){"まひるる", "#D7AFA8"}},               ///
            {"雪城眞尋", new List<string>(){"まひるる", "#B4E9FF"}},

            {"エクス・アルビオ", new List<string>(){"LvEx", "#5C9BBC"}},
            {"レヴィ・エリファ", new List<string>(){"LvEx", "#E8E1E8"}},

            {"葉山舞鈴", new List<string>(){"乳山", "#D9EC33"}},
            {"ニュイ・ソシエール", new List<string>(){"乳山", "#D24E5F"}},

            {"葉加瀬冬雪", new List<string>(){"SMC組", "#EEFFFF"}},
            {"加賀美ハヤト", new List<string>(){"SMC組", "#B9ADB9"}},
            {"夜見れな", new List<string>(){"SMC組", "#F7265A"}},

            {"黛灰", new List<string>(){"ぶるーず", "#086776"}},
            {"アルス・アルマル", new List<string>(){"ぶるーず", "#7FD6E2"}},
            {"相羽ういは", new List<string>(){"ぶるーず", "#324CAC"}},
            
            {"天宮こころ", new List<string>(){"ぽさんけ", "#C5EDFF"}},
            {"エリー・コニファー", new List<string>(){"ぽさんけ", "#DAFFF9"}},
            {"ラトナ・プティ", new List<string>(){"ぽさんけ", "#F8B759"}},
            
            {"早瀬走", new List<string>(){"チューリップ組", "#AA7BE8"}},
            {"健屋花那", new List<string>(){"チューリップ組", "#FF2FA2"}},
            {"シェリン・バーガンディ", new List<string>(){"チューリップ組", "#6C2735"}},

            {"フミ", new List<string>(){"織姫星", "#F4E49D"}},
            {"星川サラ", new List<string>(){"織姫星", "#FAB80D"}},
            {"山神カルタ", new List<string>(){"織姫星", "#384B5A"}},

            {"えま★おうがすと", new List<string>(){"赤の組織", "#B32F51"}},
            {"ルイス・キャミー", new List<string>(){"赤の組織", "#E86A74"}},
            {"魔使マオ", new List<string>(){"赤の組織", "#C93965"}},

            {"不破湊", new List<string>(){"夜王国", "#BF69F4"}},
            {"白雪巴", new List<string>(){"夜王国", "#6E3FE7"}},
            {"グウェル・オス・ガール", new List<string>(){"夜王国", "#F04B2D"}},
            
            {"ましろ", new List<string>(){"まななつ", "#1E2232"}},
            {"奈羅花", new List<string>(){"まななつ", "#A02655"}},
            {"来栖夏芽", new List<string>(){"まななつ", "#880223"}},

            {"フレン・E・ルスタリオ", new List<string>(){"メイフ", "#EC1D2F"}},
            {"メリッサ・キンレンカ", new List<string>(){"メイフ", "#D3F377"}},
            {"イブラヒム", new List<string>(){"メイフ", "#7CA1F0"}},

            {"長尾景", new List<string>(){"VΔLZ", "#625DA1"}},
            {"弦月藤士郎", new List<string>(){"VΔLZ", "#487591"}},
            {"甲斐田晴", new List<string>(){"VΔLZ", "#4DD7E3"}},
            
            //{"空星きらめ", new List<string>(){"きらめろ", "#44DDF4"}},
            
            {"朝日南アカネ", new List<string>(){"セレ女", "#B7282E"}},
            {"周央サンゴ", new List<string>(){"セレ女", "#EF8468"}},
            {"東堂コハク", new List<string>(){"セレ女", "#EA930A"}},
            {"北小路ヒスイ", new List<string>(){"セレ女", "#38B48B"}},
            {"西園チグサ", new List<string>(){"セレ女", "#3A8FB7"}},

            {"アクシア・クローネ", new List<string>(){"エデン組", "#00A6FE"}},
            {"ローレン・イロアス", new List<string>(){"エデン組", "#C10E49"}},
            {"レオス・ヴィンセント", new List<string>(){"エデン組", "#234AB7"}},
            {"オリバー・エバンス", new List<string>(){"エデン組", "#BCC37E"}},
            {"レイン・パターソン", new List<string>(){"エデン組", "#F74848"}},
        };

        num_livers = liversinfo.Count;
        names = liversinfo.Keys.ToList();

        int num = Random.Range(0, num_livers);
        string selected = names[num];
        Text selectname = GameObject.Find("Select_name").GetComponent<Text>();
        selectname.text = selected + " の";
        selectName = selected;

    }

    public void OnClickRenew()
    {
        int num = Random.Range(0, num_livers);
        string selected = names[num];
        Text selectname = GameObject.Find("Select_name").GetComponent<Text>();
        selectname.text = selected + " の";
        selectName = selected;
    }
    public void ToNormalMode()
    {
        Text selectname = GameObject.Find("Select_name").GetComponent<Text>();
        string sync = liversinfo[selectname.text.Replace(" の", "")][0];
        liversinfo.Remove(selectname.text.Replace(" の", ""));

        //Debug.Log(sync);
        //名前とカラーコードを入れたリストを作成
        synclist = new List<List<string>>();
        nsynclist = new List<List<string>>();

        foreach (KeyValuePair<string, List<string>> kvp in liversinfo)
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

        //Debug.Log(liversinfoTrue);
        GameInfo.modeflag = false;
        SceneManager.LoadScene("Game_normal");
    }

    public void ToScoreMode()
    {
        // string sync = liversinfo[selectName][0];
        // var temp = liversinfo[selectName];
        // liversinfo.Remove(selectName);

        // //Debug.Log(sync);
        // //名前とカラーコードを入れたリストを作成
        // synclist = new List<List<string>>();
        // nsynclist = new List<List<string>>();

        // foreach (KeyValuePair<string, List<string>> kvp in liversinfo)
        // {
        //     if (kvp.Value[0] == sync)
        //     {
        //         //Debug.Log(kvp.Key);
        //         synclist.Add(new List<string>() {kvp.Key, kvp.Value[1]});
        //         //Debug.Log("true added");
        //     }
        //     else
        //     {
        //         nsynclist.Add(new List<string>() {kvp.Key, kvp.Value[1]});
        //         //Debug.Log("false added");
        //     }
        // }
        // liversinfo.Add(selectName, temp);

        // //Debug.Log(liversinfoTrue);
        GameInfo.modeflag = true;
        SceneManager.LoadScene("Game_scoring");
    }
}

