using UnityEngine;
using System.Collections;

public class playmode : MonoBehaviour {
    public int flag;
    // Use this for initialization
    void Start () {
        //0:ゲームプレイ
        //1:ゲームオーバー
        //2:ゲームクリア
        //と置く
        flag = 0;
        //ここで画面サイズを指定
        Screen.SetResolution(565, 318, Screen.fullScreen);        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
