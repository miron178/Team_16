using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour {
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

	[SerializeField]
	private Transform des;
	private GameObject objectInRange = null;
	private GameObject holding = null;
	private int pickUpLayer;
	private int wallLayer;


	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody>();
		groundLayer = LayerMask.NameToLayer("Ground");

		pickUpLayer = LayerMask.NameToLayer("PickUp");
		wallLayer = LayerMask.NameToLayer("Wall");
	}

	void Update() {
		float interact = Input.GetAxis(prefix + "Interact");

		//pick up
		if (interact > 0 && !holding && objectInRange) {
			PickUp(objectInRange);
			holding = objectInRange;
			objectInRange = null;
		}

		//drop
		bool canDrop = !Physics.Linecast(transform.position, des.transform.position, 1 << wallLayer);
		if (interact < 0 && holding && canDrop) {
			Drop(holding);
			objectInRange = holding;
			holding = null;
		}
	}

	// Update is called once per frame
	void FixedUpdate() {
		float horizontal = acceleration * Input.GetAxis(prefix + "Horizontal");
		float vertical   = acceleration * Input.GetAxis(prefix + "Vertical");
		float jump       = jumpForce * Input.GetAxis(prefix + "Jump");

		Vector3 force = new Vector3(horizontal, 0, vertical);
		rb.AddRelativeForce(force * Time.fixedDeltaTime);

		//Jump
		bool grounded = Physics.Linecast(transform.position, jumpCheck.transform.position, 1 << groundLayer);
		if (grounded) {
			rb.AddRelativeForce(Vector3.up * jump * Time.fixedDeltaTime);
		}
	}

	void LateUpdate() {
		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
	}

	private void PickUp(GameObject gameObject) {
		gameObject.GetComponent<Rigidbody>().isKinematic = true;
		gameObject.transform.position = des.position;
		gameObject.transform.parent = des;
	}

	private void Drop(GameObject gameObject) {
		gameObject.GetComponent<Rigidbody>().isKinematic = false;
		//gameObject.transform.position = unchanged
		gameObject.transform.parent = null;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == pickUpLayer) {
			objectInRange = other.gameObject;
		}
	}

	private void OnTriggerExit(Collider other) {

		if (other.gameObject == objectInRange) {
			objectInRange = null;
		}
	}
}
