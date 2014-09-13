using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {


	private float movement_speed;

	// Use this for initialization
	void Start () {
		movement_speed = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Vertical")){
			transform.Translate(Vector3.forward * movement_speed * Input.GetAxis("Vertical") * Time.deltaTime);
		}
		if(Input.GetButton("Horizontal")){
			transform.Translate(Vector3.right * movement_speed * Input.GetAxis("Horizontal") * Time.deltaTime);
		}
	}
}
