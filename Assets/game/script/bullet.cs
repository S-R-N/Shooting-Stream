using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// 適用したオブジェクトの位置座標の名前をpositionと置く
	private Vector3 position;

    float speed=10f;
	void Start () {
        transform.rotation = Quaternion.Euler(transform.rotation.x - 90, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2f);
    }

	void Update () {
        //弾がZ軸に動くスピードを取る
        transform.position += new Vector3 (0f, 0f, 1f);
        transform.rotation = Quaternion.Euler(transform.rotation.x -90, 0, 0);
        //Add Componentでスクリプトをつけたゲームオブジェクトを削除(prefab化しておくこと)
        Destroy (gameObject, 3f);
	}

	//onTrigger off only
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="Enemy"){
			Destroy (gameObject,0f);
		}
	}

}
