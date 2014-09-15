using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private float movement_speed;
	private float life;
	private float damage;

	public ParticleSystem particles;

	// Use this for initialization
	public void Start () {
		//If speed has not been set, make it 10
		if(movement_speed == 0){
			movement_speed = 10f;
		}
		if(life == 0){
			life = 5f;
		}
		if(damage == 0){
			damage = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Move Up
		transform.Translate(Vector3.up * movement_speed * Time.deltaTime);

		life -= Time.deltaTime;
		if(life <= 0){
			Destroy(this.gameObject);
		}
	}

	//Set the Bullet's speed
	public void set_speed(float speed){
		movement_speed = speed;
	}

	public void set_life(float seconds){
		life = seconds;
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Enemy")){
			((Enemy) other.GetComponent(typeof(Enemy))).take_damage(damage);
			Instantiate(particles, transform.position, Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
