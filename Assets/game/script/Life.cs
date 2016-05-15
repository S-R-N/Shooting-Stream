using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Life : MonoBehaviour {
    //虹の体力のバーを表示する変数
	Image lifeber;
    //自機の体力を3と定義
	public int life=3;
    playmode playmode;
	// Use this for initialization
	void Start () {
		lifeber = GetComponent<Image>();
        playmode = GameObject.Find("EventSystem").GetComponent<playmode>();
    }
	

	void Update () {
        //自機の体力を3と置いたので体力バーを3等分
		if (life == 3) {
			lifeber.fillAmount = 1f;
		}
		else if (life == 2) {
			lifeber.fillAmount = 0.66f;
		}
		else if (life == 1) {
			lifeber.fillAmount = 0.33f;
		}
		else if (life == 0) {
			lifeber.fillAmount = 0f;
            playmode.flag = 1;
		}
	}
}
