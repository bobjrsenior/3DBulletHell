using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float movement_speed;

	// Use this for initialization
	void Start () {
		movement_speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * movement_speed * Time.deltaTime);
	}

	void set_speed(float speed){
		movement_speed = speed;
	}
}
