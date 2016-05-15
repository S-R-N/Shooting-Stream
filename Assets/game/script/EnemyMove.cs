using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	
	// 適用したオブジェクトの位置座標の名前をpositionと置く
	private Vector3 position;
	public GameObject targetprefab;
	public GameObject bullet;
	private float bulletintervalTime;
	//参照用変数
	ScoreText score;
	Life life;
    //音を入れる変数
    public AudioClip audioClip;
    AudioSource audioSource;
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        score = GameObject.Find ("Score").GetComponent<ScoreText>();
		life = GameObject.Find ("Lifeber").GetComponent<Life> ();
	}
	
	void Update () {
		//弾がZ軸に動くスピードを取る
		transform.position += new Vector3 (0f, 0f, -0.8f);
		transform.rotation = Quaternion.Euler (0, 90, 0);
		//Add Componentでスクリプトをつけたゲームオブジェクトを削除(prefab化しておくこと)
		Destroy (gameObject, 5f);

		//発射した時間を計る
		bulletintervalTime += Time.deltaTime;
		if(bulletintervalTime>=0.7f){
			bulletintervalTime=0f;
			//targetprefabで選択されたオブジェクトを出現させる
			Instantiate(bullet,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z-5f),Quaternion.Euler(90f,0,0));
		}
	}

	//onTrigger off only
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="P-bullet"){
			Destroy (gameObject,0f);
			Instantiate(targetprefab,gameObject.transform.position,gameObject.transform.rotation);
			score.score+=300;
            audioSource.PlayOneShot(audioClip);
        }
		else if(collision.gameObject.tag=="Player"){
			Destroy (gameObject,0f);
			Instantiate(targetprefab,gameObject.transform.position,gameObject.transform.rotation);
			life.life--;
            audioSource.PlayOneShot(audioClip);
        }
	}

}
