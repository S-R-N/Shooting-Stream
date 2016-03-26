using UnityEngine;
using System.Collections;

public class MouseSynchronizeObjectScript : MonoBehaviour {

	// 適用したオブジェクトの位置座標の名前をpositionと置く 
	private Vector3 position; 
	// スクリーン座標をワールド座標に変換した位置座標を以下のように置く 
	private Vector3 screenToWorldPointPosition; 
	//ここで出現させたいオブジェクトを選択欄をスクリプト内では以下のように置く
	public GameObject targetprefab;
	//弾を発射したときの時間を入れる関数
	private float bulletintervalTime;
	void Start () { 
	 	 
	} 
		
	void Update () { 
		// Vector3でマウス位置座標を取得する 
		position = Input.mousePosition; 
		// Z軸修正 
		position.z = 11f; 
		// マウス位置座標をスクリーン座標からワールド座標に変換する 
		screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position); 
		// ワールド座標に変換されたマウス座標を代入 
		gameObject.transform.position = screenToWorldPointPosition;
		//発射した時間を計る
		bulletintervalTime += Time.deltaTime;
		//左クリックしたとき
		if(Input.GetMouseButton(0)){
			//弾が出過ぎないように0.2秒以下は反応しない
			if(bulletintervalTime>=0.2f){
				bulletintervalTime=0f;
			//targetprefabで選択されたオブジェクトを出現させる
			Instantiate(targetprefab,gameObject.transform.position,gameObject.transform.rotation);
				}
			}
		} 
} 


