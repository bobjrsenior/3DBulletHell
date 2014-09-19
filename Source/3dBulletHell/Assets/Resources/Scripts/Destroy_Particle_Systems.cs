using UnityEngine;
using System.Collections;

public class Destroy_Particle_Systems : MonoBehaviour {

	float life;
	float timer;

	// Use this for initialization
	void Start () {
		life = particleSystem.duration + particleSystem.startLifetime;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= life){
			Destroy(this.gameObject);
		}
	}
}
