using UnityEngine;
using System.Collections;

public class Del : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 2.5f);
	}
}
