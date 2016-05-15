using UnityEngine;
using System.Collections;

public class E_bullet : MonoBehaviour {
	
	// 適用したオブジェクトの位置座標の名前をpositionと置く
	private Vector3 position;
	public GameObject targetprefab;
	public GameObject targetposition;
	/*
	Vector3 pos;
	Vector3 tpos;
	*/
	Life life;
	void Start () {
		/*
		pos=gameObject.transform.position;
		tpos = targetposition.gameObject.transform.position;
		*/
		life = GameObject.Find ("Lifeber").GetComponent<Life> ();
	}
	
	void Update () {
		/*本当は敵が弾発射したときのプレイヤーの位置を保持してそこに飛ばしたかった
		transform.LookAt (tpos);
		transform.position += new Vector3 ((pos.x - tpos.x) / 10,(pos.y - tpos.y) / 10,(pos.z - tpos.z) / 10);
		*/
		//弾がZ軸に動くスピードを取る
		transform.position += new Vector3 (0f,0f,-2f);
		//Add Componentでスクリプトをつけたゲームオブジェクトを削除(prefab化しておくこと)
		Destroy (gameObject, 2.3f);
	}

	//onTrigger off only
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="Player"){
			Destroy (gameObject,0f);
			life.life--;
		}
	}
}
