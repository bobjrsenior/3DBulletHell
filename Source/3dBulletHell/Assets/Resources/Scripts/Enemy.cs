using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float health;
	private float movement_speed;

	public ParticleSystem particles;

	// Use this for initialization
	void Start () {
		health = 10f;
		movement_speed = 15f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void take_damage(float damage){
		Debug.Log ("hit2");
		health -= damage;
		if(health <= 0){
			Instantiate(particles, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
