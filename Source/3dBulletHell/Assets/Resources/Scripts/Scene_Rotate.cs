using UnityEngine;
using System.Collections;

public class Scene_Rotate : MonoBehaviour {

	private GameObject Ship;

	private float rotate_speed;
	private float rotation_amount;

	// Use this for initialization
	void Start () {
		Ship = GameObject.FindWithTag("Player");
		rotate_speed = 30f;
	}
	
	// Update is called once per frame
	void Update () {
		rotation_amount = rotate_speed * Input.GetAxis("Mouse X") * Time.deltaTime;
		transform.Rotate(Vector3.up * rotation_amount);
		Ship.transform.Rotate(Vector3.up * rotation_amount);
	}
}
