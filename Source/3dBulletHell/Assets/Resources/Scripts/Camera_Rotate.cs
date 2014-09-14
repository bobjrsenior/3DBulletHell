using UnityEngine;
using System.Collections;

public class Camera_Rotate : MonoBehaviour {

	private float rotate_speed;

	// Use this for initialization
	void Start () {
		rotate_speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * rotate_speed * Input.GetAxis("Mouse X") * Time.deltaTime);
	}
}
