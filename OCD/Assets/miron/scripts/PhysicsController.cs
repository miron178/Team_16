using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour {
//privates for player control
	[SerializeField]
	private float acceleration = 100000f;
	private Rigidbody rb;
	[SerializeField]
	private string prefix = "P2";
	[SerializeField]
	private float maxSpeed = 1f;
	[SerializeField]
	private float jumpForce = 100000f;
	[SerializeField]
	private GameObject jumpCheck;
	private int groundLayer;

//privates for pickup
	[SerializeField]
	private Transform des;
	private GameObject objectInRange = null;
	private GameObject holding = null;
	private int pickUpLayer;
	private int wallLayer;

	void Start() {
		rb = GetComponent<Rigidbody>(); //used later to make code more readable
		
		//layer dependancies
		groundLayer = LayerMask.NameToLayer("Ground");
		pickUpLayer = LayerMask.NameToLayer("PickUp");
		wallLayer   = LayerMask.NameToLayer("Wall"  );

	}

	void FixedUpdate() {
#if true //player controles
			float horizontal = acceleration * Input.GetAxis(prefix + "Horizontal"); //movment
			float vertical = acceleration * Input.GetAxis(prefix + "Vertical"); //movment
			float jump = jumpForce * Input.GetAxis(prefix + "Jump"); //jump
			float interact = Input.GetAxis(prefix + "Interact"); //pickUp and drop

		Vector3 force = new Vector3(horizontal, 0, vertical);
		rb.AddRelativeForce(force * Time.fixedDeltaTime);

		//Jump
		bool grounded = Physics.Linecast(transform.position, jumpCheck.transform.position, 1 << groundLayer); //checks if player is grounded
		if (grounded) {
			rb.AddRelativeForce(Vector3.up * jump * Time.fixedDeltaTime);
		}

		//pick up
		if (interact > 0 && !holding && objectInRange) {
			PickUp(objectInRange);
			holding = objectInRange;
			objectInRange = null;
		}

		//drop
		bool canDrop = !Physics.Linecast(transform.position, des.transform.position, 1 << wallLayer); //stops dropping through walls
		if (interact < 0 && holding && canDrop) {
			Drop(holding);
			objectInRange = holding;
			holding = null;
#endif
		}
	}

	void LateUpdate() {
		if (rb.velocity.magnitude > maxSpeed) { 
			rb.velocity = rb.velocity.normalized * maxSpeed; //stops objects moving faster than max speed
		}
	}

	private void PickUp(GameObject gameObject) {
		gameObject.GetComponent<Rigidbody>().isKinematic = true; //makes picked up objects kinimatic to stop physics
		gameObject.transform.position = des.position; //moves object to des(destination)
		gameObject.transform.parent = des; //makes object chiled when being picked up
	}

	private void Drop(GameObject gameObject) {
		gameObject.GetComponent<Rigidbody>().isKinematic = false; //makes object not kinematic
		gameObject.transform.parent = null; //object is no longer has parant
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == pickUpLayer) {
			objectInRange = other.gameObject; //checks if object is in range
		}
	}

	private void OnTriggerExit(Collider other) {

		if (other.gameObject == objectInRange) {
			objectInRange = null; //stops objects being flaged as in range after they leave trigger
		}
	}
}
