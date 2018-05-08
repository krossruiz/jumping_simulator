using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TedController : MonoBehaviour {

	enum TedJumpStates {
		HAS_NOT_JUMPED,
		HAS_JUMPED_ONCE,
		HAS_JUMPED_TWICE
	}

	private TedJumpStates jump_state;
	private Rigidbody rb;
	private Animator animator;
	public Vector3 takeoff_jump_velocity;
	public Vector3 double_jump_velocity;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		animator = this.GetComponent<Animator> ();
		SetJumpState (TedJumpStates.HAS_NOT_JUMPED);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ResetJumpState(){
		SetJumpState (TedJumpStates.HAS_NOT_JUMPED);
	}

	public void InvokeJump(){
		switch (jump_state) {
		case(TedJumpStates.HAS_NOT_JUMPED):
			rb.velocity = takeoff_jump_velocity;
			SetJumpState(TedJumpStates.HAS_JUMPED_ONCE);
			break;
		case(TedJumpStates.HAS_JUMPED_ONCE):
			rb.velocity = double_jump_velocity;
			SetJumpState(TedJumpStates.HAS_JUMPED_TWICE);
			break;
		default:
			break;
		}
	}

	void SetJumpState(TedJumpStates state){
		switch(state){
		case(TedJumpStates.HAS_NOT_JUMPED):
			jump_state = TedJumpStates.HAS_NOT_JUMPED;
			animator.SetBool ("HAS_NOT_JUMPED", true);
			animator.SetBool ("HAS_JUMPED_ONCE", false);
			animator.SetBool ("HAS_JUMPED_TWICE", false);
			break;
		case(TedJumpStates.HAS_JUMPED_ONCE):
			jump_state = TedJumpStates.HAS_JUMPED_ONCE;
			animator.SetBool ("HAS_NOT_JUMPED", false);
			animator.SetBool ("HAS_JUMPED_ONCE", true);
			animator.SetBool ("HAS_JUMPED_TWICE", false);
			break;
		case(TedJumpStates.HAS_JUMPED_TWICE):
			jump_state = TedJumpStates.HAS_JUMPED_TWICE;
			animator.SetBool ("HAS_NOT_JUMPED", false);
			animator.SetBool ("HAS_JUMPED_ONCE", false);
			animator.SetBool ("HAS_JUMPED_TWICE", true);
			break;
		default:
			break;
		}
	}
}
