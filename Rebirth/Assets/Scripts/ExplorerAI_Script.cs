using UnityEngine;
using System.Collections;

public class ExplorerAI_Script : MonoBehaviour {
	public float movementSpeed = 1;
	
	public enum MovementStates{
		STANDING,
		WALKINGRIGHT,
		WALKINGUP,
		WALKINGDOWN,
		WALKINGLEFT,
	};
	public MovementStates currentMovementState = MovementStates.WALKINGRIGHT;

	// Update is called once per frame
	void Update () {
		switch (currentMovementState) {
		case MovementStates.STANDING:
			StandingStateOnUpdate ();
			break;
		case MovementStates.WALKINGRIGHT:
			WalkingStateOnUpdate (this.transform.forward);
			break;
		case MovementStates.WALKINGLEFT:
			WalkingStateOnUpdate (-this.transform.forward);
			break;
		case MovementStates.WALKINGDOWN:
			WalkingStateOnUpdate (this.transform.right);
			break;
		case MovementStates.WALKINGUP:
			WalkingStateOnUpdate (-this.transform.right);
			break;
		default:
			StandingStateOnUpdate ();
			break;
		}
	}
	
	void OnTriggerEnter(Collider collider){
		ChangeMotionState (collider.tag);
	}
	

	public void ChangeMotionState(string colliderTriggerTag){
		switch (colliderTriggerTag){
		case "STOP" : this.currentMovementState = MovementStates.STANDING; break;
		case "WALKRIGHT" : this.currentMovementState = MovementStates.WALKINGRIGHT; break;
		case "WALKLEFT" : this.currentMovementState = MovementStates.WALKINGLEFT; break;
		case "WALKUP" : this.currentMovementState = MovementStates.WALKINGUP; break;
		case "WALKDOWN" : this.currentMovementState = MovementStates.WALKINGDOWN; break;
			
		default: this.currentMovementState = MovementStates.STANDING; break;
		}
	}
	
	public void WalkingStateOnUpdate(Vector3 direction){
		this.rigidbody.velocity = direction * movementSpeed;
	}
	
	public void StandingStateOnUpdate(){
		this.rigidbody.velocity = Vector3.zero;
	}
}
