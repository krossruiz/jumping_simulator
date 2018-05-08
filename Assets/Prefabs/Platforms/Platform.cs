using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public Vector3 velocity;
	public float lifetime_in_seconds = 10;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		Invoke ("destroyPlatform", 10f);
	}
	
	// Update is called once per frame
	void Update () {
		//rb.velocity = velocity;
		transform.Translate (velocity*Time.deltaTime);
	}

	void destroyPlatform(){
		Destroy(gameObject);
	}
}
