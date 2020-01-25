using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour {
	[SerializeField]
	private float acceleration = 100000;
	private Rigidbody rb;
	[SerializeField]
	private string prefix = "P1";
	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate() {
		float horizontal = acceleration * Input.GetAxis(prefix + "Horizontal");
		float vertical = acceleration * Input.GetAxis(prefix + "Vertical");

		rb.AddForce(
			Vector3.right * horizontal * Time.fixedDeltaTime +
			Vector3.forward * vertical * Time.fixedDeltaTime);
	}
}
