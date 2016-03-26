using UnityEngine;
using System.Collections;

public class EnemyInstantiate : MonoBehaviour {

	//ここで出現させたいオブジェクトを選択欄をスクリプト内では以下のように置く
	public GameObject targetprefab;
	//敵が出現したときの時間を入れる関数
	private float enemyintervalTime;
	private Vector3 position;
	public int enemyMax;

	void Start () {
/*
		Instantiate(targetprefab,pos,gameObject.transform.rotation);
		enemyMax++;*/
		enemyMax = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//出現した時間を計る
		enemyintervalTime += Time.deltaTime;
		Vector3 pos = new Vector3 (Random.Range (-6.0f, 6.0f),Random.Range (-4, 4) , 60f);
		//11体以上は出ない
		if(enemyMax<=10){
			//敵が出過ぎないように0.5秒以下は反応しない
			if (enemyintervalTime >= 0.5f) {
				enemyintervalTime = 0f;
				//if(Random.value==0){
				Instantiate(targetprefab,pos,gameObject.transform.rotation);
				enemyMax++;
				//}
			}
		}
	}

}