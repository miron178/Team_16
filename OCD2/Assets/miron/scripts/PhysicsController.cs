using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour {
	[SerializeField]
	private float acceleration = 100000f;
	private Rigidbody rb;
	[SerializeField]
	private string prefix = "P1";
	[SerializeField]
	private float maxSpeed = 1f;
	[SerializeField]
	private float jumpForce = 100000f;
	[SerializeField]
	private GameObject jumpCheck;
	private int groundLayer;

	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody>();
		groundLayer = LayerMask.NameToLayer("Ground"); 
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
}
