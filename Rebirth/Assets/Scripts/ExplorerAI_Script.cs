using UnityEngine;
using System.Collections;

public class ExplorerAI_Script : MonoBehaviour {
	public bool shouldMoveForward = true;
	public float movementSpeed = 1;
	public enum MovementStates{
		STANDING,
		WALKINGRIGHT,
		WALKINGUP,
		WALKINGDOWN,
		WALKINGLEFT,
	};

	public MovementStates currentMovementState = MovementStates.WALKINGRIGHT;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentMovementState) {
			case MovementStates.STANDING: StandingStateOnUpdate(); break;
		    case MovementStates.WALKINGRIGHT: WalkingStateOnUpdate(this.transform.forward); break;
			case MovementStates.WALKINGLEFT: WalkingStateOnUpdate(-this.transform.forward); break;
			case MovementStates.WALKINGDOWN: WalkingStateOnUpdate(this.transform.right); break;
			case MovementStates.WALKINGUP: WalkingStateOnUpdate(-this.transform.right); break;
			default: StandingStateOnUpdate(); break;
		}
	}

	void WalkingStateOnUpdate(Vector3 direction){
		this.rigidbody.velocity = direction * movementSpeed;
	}

	void StandingStateOnUpdate(){
		
	}

	void OnTriggerEnter(Collider collider){
		ChangeMotionState (collider.tag);
	}

	void ChangeMotionState(string colliderTriggerTag){
		switch (colliderTriggerTag){
			case "STOP" : this.currentMovementState = MovementStates.STANDING; break;
		    case "WALKRIGHT" : this.currentMovementState = MovementStates.WALKINGRIGHT; break;
			case "WALKLEFT" : this.currentMovementState = MovementStates.WALKINGLEFT; break;
			case "WALKUP" : this.currentMovementState = MovementStates.WALKINGUP; break;
			case "WALKDOWN" : this.currentMovementState = MovementStates.WALKINGDOWN; break;

			default: this.currentMovementState = MovementStates.STANDING; break;
		}
	}
}
