﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider){
		Debug.Log ("Head is hit, ow!");
		GetComponentInParent<TedController> ().ResetJumpState();
	}

}
