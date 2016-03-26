using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	// 適用したオブジェクトの位置座標の名前をpositionと置く
	private Vector3 position;
	//敵が出現したときの時間を入れる関数
	private float enemyTime;
	EnemyInstantiate enemyInstantiate;
	// Use this for initialization
	void Start () {
		enemyInstantiate = GetComponent<EnemyInstantiate> ();
	}
	
	// Update is called once per frame
	void Update () {
		//敵がZ軸に動くスピードを取る
		transform.position += new Vector3 (0f, 0f, -0.1f);
		enemyTime += Time.deltaTime;
		if (enemyTime >= 1f) {
			enemyInstantiate.enemyMax--;
			GameObject.Destroy (gameObject);
		}
	}
	//isTrigger off only
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "P-bullet") {
			enemyInstantiate.enemyMax-=1;
			GameObject.Destroy(this.gameObject,0f);
		}
		else if (collision.gameObject.tag == "Player") {
			enemyInstantiate.enemyMax-=1;
			Destroy(this.gameObject,0f);
		}
	}
}
