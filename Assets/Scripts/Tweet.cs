using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tweet : MonoBehaviour
{
    string tweet_text;
    
#if !UNITY_EDITOR && UNITY_WEBGL
    [System.Runtime.InteropServices.DllImport("__Internal")]
    static extern string TweetFromUnity(string rawMessage);
#endif

    public void tweet()
    {
        tweet_text = "スコアは【" + GameInfo.score + "】点で%0aランクは【" + ResultInfo.rank.text + "】でした！%0a%23にじさんじ同期集め%0a%0ahttps://unityroom.com/games/nijigame";
#if !UNITY_EDITOR && UNITY_WEBGL
        TweetFromUnity(tweet_text);
        return;
#endif
        Application.OpenURL($"https://twitter.com/intent/tweet?text={tweet_text}");
    }
}