using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {
	//制限時間を60秒とセット
	private float gametime;
	public Text text;
    //参照用変数
    playmode playmode;
	void Start () {
        playmode = GameObject.Find("EventSystem").GetComponent<playmode>();
        //ゲームの時間を60秒と設定
        gametime = 60f;
    }
	
	// Update is called once per frame
	void Update () {
        //ゲームモードがプレイ中の時
        if (playmode.flag == 0)
        {
            //時間を減らす
            gametime -= Time.deltaTime;
            text.text = "TIME:" + gametime;
            if (gametime < 0)
            {
                //ゲームモードを変更(クリア)
                playmode.flag = 2;
                gametime = 0;
            }
        }
        //クリア中はタイムに0を代入し続けてマイナスの時間を消す予定だった
        else if (playmode.flag == 2)
        {
            gametime = 0;
        }
	}
}
