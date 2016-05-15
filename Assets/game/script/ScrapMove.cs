using UnityEngine;
using System.Collections;

public class ScrapMove : MonoBehaviour {
	
	// 適用したオブジェクトの位置座標の名前をpositionと置く
	private Vector3 position;
	public GameObject effect;
	//参照用変数
	ScoreText score;
	Life life;
    playmode playmode;
    //音をセットする変数
    public AudioClip ac;
	AudioSource ausrc;
    
	void Start () {
        ausrc = gameObject.GetComponent<AudioSource>();
        score = GameObject.Find ("Score").GetComponent<ScoreText>();
		life = GameObject.Find ("Lifeber").GetComponent<Life> ();
        playmode = GameObject.Find("EventSystem").GetComponent<playmode>();
	}
	
	void Update () {
		//スクラップがZ軸に動くスピードを取る
		transform.position += new Vector3 (0f, 0f, -0.4f);
        //回転する角度と速度を指定
		transform.Rotate(new Vector3(1, -1, 0), 180*Time.deltaTime);
		//Add Componentでスクリプトをつけたゲームオブジェクトを削除(prefab化しておくこと)
		Destroy (gameObject, 8f);
        //ゲームクリアしたら全て削除
        if (playmode.flag == 2)
        {
            Destroy(gameObject, 0f);
        }
	}

	//onTrigger off only
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="P-bullet"){
			Instantiate(effect, gameObject.transform.position,gameObject.transform.rotation);
			score.score+=100;
            ausrc.PlayOneShot(ac);
            Destroy(gameObject, 0f);
        }
		else if(collision.gameObject.tag=="Player"){
			Destroy (gameObject,0f);
			Instantiate(effect, gameObject.transform.position,gameObject.transform.rotation);
			life.life--;
            ausrc.PlayOneShot(ac);
		}
		else if(collision.gameObject.tag=="E-bullet"){
			Destroy (gameObject,0f);
			Instantiate(effect, gameObject.transform.position,gameObject.transform.rotation);
			ausrc.PlayOneShot(ac);
		}
	}
}
