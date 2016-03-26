using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// 適用したオブジェクトの位置座標の名前をpositionと置く
	private Vector3 position;
	//
	//private GameObject clonefind;
	void Start () {

	}

	void Update () {
		//弾がZ軸に動くスピードを取る
		transform.position += new Vector3 (0f, 0f, 1f);
		//Add Componentでスクリプトをつけたゲームオブジェクトを削除(prefab化しておくこと)
		Destroy (gameObject, 3f);
	}
}
