using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject target;
	//private Vector3 position;
	private Vector3 position;
	// Use this for initialization
	private float dirX;
	private float dirY;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = target.transform.position;
		transform.LookAt (pos);
		dirX = (target.transform.position.x - transform.position.x)/20;
		dirY = (target.transform.position.y - transform.position.y)/20;
		transform.position = new Vector3(
			transform.position.x + dirX, 
			transform.position.y + dirY, 
			-3f);
	}
}
