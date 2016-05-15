using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
	public int score=0;
	//表示させたいTextをここに入れる
	public Text text;
	void Start () {
		
	}

	void Update () {
		//これでスコアを表示
		text.text = "SCORE:" + score.ToString("000000");
	}
}
