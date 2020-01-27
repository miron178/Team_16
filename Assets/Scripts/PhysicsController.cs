using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour {
	[SerializeField]
	private float rotation = 10000f;
	[SerializeField]
	private float acceleration = 100000f;
	private Rigidbody rb;
	[SerializeField]
	private string prefix = "P1";
	[SerializeField]
	private float rotationSpeed = 1f;
	[SerializeField]
	private float maxSpeed = 1f;

	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate() {
		float horizontal = rotation   * Input.GetAxis(prefix + "Horizontal");
		float vertical = acceleration * Input.GetAxis(prefix + "Vertical");

#if false
		rb.AddForce(Vector3.right * horizontal * Time.fixedDeltaTime);
#endif
		rb.AddRelativeForce(Vector3.forward * vertical * Time.fixedDeltaTime);
		rb.AddRelativeTorque(Vector3.up * horizontal * Time.fixedDeltaTime);
	}

	void LateUpdate() {
		if (rb.angularVelocity.magnitude > rotationSpeed) {
			rb.angularVelocity = rb.angularVelocity.normalized * rotationSpeed;
		}
		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
	}
}
