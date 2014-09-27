using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private float max_health;
	private float cur_health;
	private float health_percent;

	private float movement_speed;

	public ParticleSystem particles;
	//public GameObject health_Bar;

	// Use this for initialization
	void Start () {
		max_health = 10f;
		cur_health = max_health;
		health_percent = .5f * (cur_health / max_health);
		//health_Bar.transform.localScale	= new Vector3(health_percent, health_percent, health_percent);
		movement_speed = 15f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void take_damage(float damage){
		cur_health -= damage;
		health_percent = .5f * (cur_health / max_health);
		//health_Bar.transform.localScale	= new Vector3(health_percent, health_percent, health_percent);
		if(cur_health <= 0){
			Instantiate(particles, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
}
