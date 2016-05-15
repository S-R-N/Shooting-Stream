using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour {

	//ここで出現させたいオブジェクトを選択欄をスクリプト内では以下のように置く
	//public GameObject E_targetprefab;
	//public GameObject S_targetprefab;
	//物が出現したときの時間を入れる変数
	private float enemyintervalTime;
	private float scrapintervalTime;
	//オブジェクトの初期位置を入れる変数
	private Vector3 position;
	public static int enemy;
    //参照用変数
    playmode playmode;
    ScrapMove scarp;
	void Start () {
        playmode = GameObject.Find("EventSystem").GetComponent<playmode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playmode.flag == 0)
        {
            //出現した時間を計る
            enemyintervalTime += Time.deltaTime;
            scrapintervalTime += Time.deltaTime;
            //ランダムにオブジェクトを出現させる
            Vector3 pos = new Vector3(Random.Range(-11.5f, 11.5f), Random.Range(-5.5f, 5.5f), 52f);
            //敵が出過ぎないように4秒以下は反応しない
            if (enemyintervalTime >= 4f)
            {
                //タイムをリセット
                enemyintervalTime = 0f;
                //出現関数
		//これが通常のオブジェクトの出現のさせ方
                //Instantiate(E_targetprefab, pos, gameObject.transform.rotation);
		//こちらはiOS対応の出現関数のやり方
                GameObject E_targetprefab = Instantiate(Resources.Load("E-rocket"), pos, gameObject.transform.rotation) as GameObject;
            }
            //スクラップが出過ぎないように0.35秒以下は反応しない
            if (scrapintervalTime >= 0.35f)
            {
                //タイムをリセット
                scrapintervalTime = 0f;
                //出現関数
                //Instantiate(S_targetprefab, pos, gameObject.transform.rotation);
                GameObject S_targetprefab = Instantiate(Resources.Load("stone"), pos, gameObject.transform.rotation) as GameObject;
            }
        }
    }
}