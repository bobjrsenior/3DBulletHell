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
	//Have you hit the edge of the room?
	public bool hit_edge;


	/// Weapons
	public GameObject default_bullet;
	private float default_wep_delay;
	private float default_wep_timer;

	// Use this for initialization
	void Start () {
		movement_speed = 5;
		room_size = 10;
		room_size_square = room_size * room_size;
		hit_edge = false;

		///Weapons
		default_wep_delay = .2f;
		default_wep_timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {

	///General Movement
		h_speed = 0;
		v_speed = 0;
		x_pos = transform.position.x;
		z_pos = transform.position.z;

		//Checks if you hit the room edge (a^2 + b^2 = c^2)
		if((x_pos * x_pos) + (z_pos * z_pos) >= room_size_square){
			hit_edge = true;
		}
		else{
			hit_edge = false;
		}

		//Gets movement speed by checking input
		if(Input.GetButton("Vertical")){
			v_speed = movement_speed * Input.GetAxis("Vertical") * Time.deltaTime;
		}

		if(Input.GetButton("Horizontal")){
			h_speed = movement_speed * Input.GetAxis("Horizontal") * Time.deltaTime;
		}

		//If at an edge, make sure you don't go past it
		if(hit_edge){
			float abs_x = Mathf.Abs(x_pos);
			float abs_z = Mathf.Abs(z_pos);
			///Checking on which values to invert
			//Only invert h_speed if it isn't 0. Favor inverting the larger position (whether x or z is higher),
			//but make sure it check H-speed if v_speed = 0
			if(h_speed != 0 && (abs_x > abs_z || v_speed == 0)){
				//If you have a negative speed and are at the negative edge of the room, invert
				//If you have a positive speed and are at the positive edge of the room, invert
				if((h_speed < 0 && x_pos < 0) || (h_speed > 0 && x_pos > 0)){
					h_speed *= -1;
				}
			}
			//Same as h_speed invertion
			else if(v_speed != 0 && (abs_x < abs_z || h_speed == 0)){
				if((v_speed < 0 && z_pos < 0) || (v_speed > 0 && z_pos > 0)){
					v_speed *= -1;
				}
			}
			else{
				//Same as the insides of the other if statements
				if((h_speed < 0 && x_pos < 0) || (h_speed > 0 && x_pos > 0)){
					h_speed *= -1;
				}
				if((v_speed < 0 && z_pos < 0) || (v_speed > 0 && z_pos > 0)){
					v_speed *= -1;
				}
			}
		}

		//Actually Move
		transform.Translate(Vector3.forward * v_speed);
		transform.Translate(Vector3.right * h_speed);

	///Firing Weapons
		if(default_wep_timer > 0){
			default_wep_timer -= Time.deltaTime;
		}
		if(Input.GetButton("Fire_Default") || Input.GetMouseButton(0)){
			if(default_wep_timer <= 0){
				default_wep_timer = default_wep_delay;
				GameObject bullet = Instantiate(default_bullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity) as GameObject;
			}
		}
	}
}
