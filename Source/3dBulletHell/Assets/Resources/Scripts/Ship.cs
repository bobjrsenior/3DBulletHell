using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {


	private float movement_speed;
	private float h_speed;
	private float v_speed;
	private float x_pos;
	private float z_pos;
	//The distance the ship can travel from origin
	public int room_size;
	private int room_size_square;
	//Have you hit the edge of the room? -1=yes 1=no
	public bool hit_edge;

	// Use this for initialization
	void Start () {
		movement_speed = 5;
		room_size = 10;
		room_size_square = room_size * room_size;
		hit_edge = false;
	}
	
	// Update is called once per frame
	void Update () {
		h_speed = 0;
		v_speed = 0;
		x_pos = transform.position.x;
		z_pos = transform.position.z;
		if((transform.position.x * transform.position.x) + (transform.position.z * transform.position.z) >= room_size_square){
			hit_edge = true;
		}
		else{
			hit_edge = false;
		}
		if(Input.GetButton("Vertical")){
			v_speed = movement_speed * Input.GetAxis("Vertical") * Time.deltaTime;
			/*if(transform.position.z > 10){
				transform.position = new Vector3(transform.position.x, 0, 10);
			}
			else if(transform.position.z < -10){
				transform.position = new Vector3(transform.position.x, 0, -10);
			}*/
		}

		if(Input.GetButton("Horizontal")){
			h_speed = movement_speed * Input.GetAxis("Horizontal") * Time.deltaTime;

			/*if(transform.position.x > 10){
				transform.position = new Vector3(10, 0, transform.position.z);
			}
			else if(transform.position.x < -10){
				transform.position = new Vector3(-10, 0, transform.position.z);
			}*/
		}

		if(hit_edge){
			float abs_x = Mathf.Abs(transform.position.x);
			float abs_z = Mathf.Abs(transform.position.z);
			if(abs_x > abs_z){
				if((h_speed < 0 && x_pos < 0) || (h_speed > 0 && x_pos > 0)){
					h_speed *= -1;
				}
			}
			else if(abs_x < abs_z){
				if((v_speed < 0 && z_pos < 0) || (v_speed > 0 && z_pos > 0)){
					v_speed *= -1;
				}
			}
			else{
				if((h_speed < 0 && x_pos < 0) || (h_speed > 0 && x_pos > 0)){
					h_speed *= -1;
				}
				if((v_speed < 0 && z_pos < 0) || (v_speed > 0 && z_pos > 0)){
					v_speed *= -1;
				}
			}
		}
		transform.Translate(Vector3.forward * v_speed);
		transform.Translate(Vector3.right * h_speed);
	}
}
