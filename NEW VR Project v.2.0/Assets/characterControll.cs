using UnityEngine;
using System.Collections;

public class characterControll : MonoBehaviour {

	// Use this for initialization
	public  float _speed = 0.0016f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,gameObject.transform.position .z+ _speed);
	}
}
