using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameText : MonoBehaviour {
    public Text text;
    playmode playmode;
    ScoreText score;
    GameObject position;
    //処理を止める変数をセット
    float waittime;
    void Start () {
        playmode = GameObject.Find("EventSystem").GetComponent<playmode>();
        score = GameObject.Find("Score").GetComponent<ScoreText>();
        //テキストの位置調整
        gameObject.transform.position = new Vector3(gameObject.transform.position.x+10f, gameObject.transform.position.y+10f, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //ゲームモードがプレイ以外になった瞬間に数える
        if (playmode.flag != 0)
        {
            waittime += Time.deltaTime;
        }
        if (playmode.flag == 1)
        {
            text.text = "Game Over...\nscore:"+score.score;
        }
        else if (playmode.flag == 2)
        {
            if (0 <= score.score && score.score <= 3000)
            {
                text.text = "GameClear!!\nscore:" + score.score+"\nRANK:E";
            }
            else if (3100 <= score.score && score.score <= 5000)
            {
                text.text = "GameClear!!\nscore:" + score.score + "\nRANK:D";
            }
            else if (5100 <= score.score && score.score <= 7000)
            {
                text.text = "GameClear!!\nscore:" + score.score + "\nRANK:C";
            }
            else if (7100 <= score.score && score.score <= 8100)
            {
                text.text = "GameClear!!\nscore:" + score.score + "\nRANK:B";
            }
            else if (9100 <= score.score && score.score <= 10000)
            {
                text.text = "GameClear!!\nscore:" + score.score + "\nRANK:A";
            }
            else if (10100 <= score.score && score.score <= 11000)
            {
                text.text = "GameClear!!\nscore:" + score.score + "\nRANK:S";
            }
            else if (11100 <= score.score && score.score <= 12000)
            {
                text.text = "GameClear!!\nscore:" + score.score + "\nRANK:SS";
            }
            else if (12100 <= score.score)
            {
                text.text = "GameClear!!\nscore:" + score.score + "\nRANK:SSS\nMAXRECORD!!!!";
            }
            

        }
	
	}
    void OnGUI()
    {
        if (playmode.flag != 0)
        {
            if (waittime >= 3f)
            {
                //3秒間待ってGUIボタンを表示する
                if (GUI.Button(new Rect(100, 230, 150, 30), "Continue"))
                {
                    Application.LoadLevel("game");
                }
                if (GUI.Button(new Rect(300, 230, 150, 30), "Twitterへ投稿"))
                {
                    // WebブラウザのTwitter投稿画面を開く 
                    Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(text.text+"\nソースコード・ゲームDLはこちら https://github.com/S-R-N/Shooting-Stream\n#shootingstream"));
                }
                /*
                if (GUI.Button(new Rect(380, 230, 150, 30), "Lineへ共有"))
                {
                    // Lineに投稿 
                    Application.OpenURL("http://line.naver.jp/R/msg/text/?" + WWW.EscapeURL(text.text, System.Text.Encoding.UTF8));
                }
		//なぜかPCではLineはうまく動かなかったの実装しない方向で
                */
            }
        }
    }
}
