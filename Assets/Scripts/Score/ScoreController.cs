using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public static int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update (){
	}

	public static void increment_score(int increment){
		score += increment;
	}

	public static int getScore(){
		return score;
	}
}
