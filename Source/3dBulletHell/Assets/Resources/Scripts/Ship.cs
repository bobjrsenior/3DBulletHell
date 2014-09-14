using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {


	private float movement_speed;
	//The distance the ship can travel from origin
	public int room_size;
	private int room_size_square;
	//Have you hit the edge of the room? -1=yes 1=no
	public int hit_edge;

	// Use this for initialization
	void Start () {
		movement_speed = 5;
		room_size = 10;
		room_size_square = room_size * room_size;
		hit_edge = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if((transform.position.x * transform.position.x) + (transform.position.z * transform.position.z) >= room_size_square){
			hit_edge = -1;
		}
		else{
			hit_edge = 1;
		}
		if(Input.GetButton("Vertical")){
			transform.Translate(Vector3.forward * movement_speed * hit_edge *Input.GetAxis("Vertical") * Time.deltaTime);
			if(transform.position.z > 10){
				transform.position = new Vector3(transform.position.x, 0, 10);
			}
			else if(transform.position.z < -10){
				transform.position = new Vector3(transform.position.x, 0, -10);
			}
		}
		if((transform.position.x * transform.position.x) + (transform.position.z * transform.position.z) >= room_size_square){
			hit_edge = -1;
		}
		else{
			hit_edge = 1;
		}
		if(Input.GetButton("Horizontal")){
			transform.Translate(Vector3.right * movement_speed * hit_edge * Input.GetAxis("Horizontal") * Time.deltaTime);

			if(transform.position.x > 10){
				transform.position = new Vector3(10, 0, transform.position.z);
			}
			else if(transform.position.x < -10){
				transform.position = new Vector3(-10, 0, transform.position.z);
			}
		}
	}
}
