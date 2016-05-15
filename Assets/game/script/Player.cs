using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //特定のオブジェクトを入れる変数
	public GameObject target;
	private Vector3 position;
    //このスクリプトがついてるオブジェクトとターゲットのオブジェクトの差分を入れる変数
	private float dirX;
	private float dirY;
	private float AxisY;
    //自機がやられたときのエフェクトを指定する変数
    public GameObject effect;
    Life life;
    void Start () {
        life = GameObject.Find("Lifeber").GetComponent<Life>();
    }

	void Update () {
        //向きを指定したオブジェクトに回転させる
		Vector3 pos = target.transform.position;
		transform.LookAt (pos);
        //長い名前なので変数化
		AxisY=transform.localEulerAngles.y;
        //3DSMAXから吐き出した時に90度回転した状態でUnityに読み込まれたので調整 
		transform.rotation = Quaternion.Euler(0, AxisY-90, 0);
        //このスクリプトがついたオブジェクトとターゲットの位置の差分を調べる　/の後ろの数字は近づく速さ(値が小さいほど速い)
		dirX = (target.transform.position.x - transform.position.x)/15;
		dirY = (target.transform.position.y - transform.position.y)/15;
        //これで差を時間差で埋める　最終的に”ほぼ”同じになる
		transform.position = new Vector3(
			transform.position.x + dirX, 
			transform.position.y + dirY, 
			-3f);
        //体力が0になったら自機が爆発
        if (life.life == 0)
        {
            Instantiate(effect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject, 0f);
        }
	}
}
