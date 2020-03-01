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
	private GameObject groundCheck;

	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate() {
		float horizontal = acceleration * Input.GetAxis(prefix + "Horizontal");
		float vertical   = acceleration * Input.GetAxis(prefix + "Vertical");
		float jump       = jumpForce * Input.GetAxis(prefix + "Jump");

		rb.AddRelativeForce(Vector3.right * horizontal * Time.fixedDeltaTime);
		rb.AddRelativeForce(Vector3.forward * vertical * Time.fixedDeltaTime);

		//Jump
		bool grounded = Physics.Linecast(transform.position, groundCheck.transform.position);
		if (grounded) {
			//rb.AddRelativeForce(Vector3.up * jump * Time.fixedDeltaTime);
		}
	}

	void LateUpdate() {
		if (rb.velocity.magnitude > maxSpeed) {
			//rb.velocity = rb.velocity.normalized * maxSpeed;
		}
	}
}
