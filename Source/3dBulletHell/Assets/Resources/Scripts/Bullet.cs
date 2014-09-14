using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float movement_speed;

	// Use this for initialization
	public void Start () {
		//If speed has not been set, make it 10
		if(movement_speed == 0){
			movement_speed = 10f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Move Up
		transform.Translate(Vector3.up * movement_speed * Time.deltaTime);
	}

	//Set the Bullet's speed
	public void set_speed(float speed){
		movement_speed = speed;
	}
}
