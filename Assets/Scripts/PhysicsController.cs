﻿using System.Collections;
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
	[SerializeField]
	private float jumpForce = 100000f;

	// Start is called before the first frame update
	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate() {
		float horizontal = rotation     * Input.GetAxis(prefix + "Horizontal");
		float vertical   = acceleration * Input.GetAxis(prefix + "Vertical");
		float jump       = jumpForce * Input.GetAxis(prefix + "Jump");

		//move left and right
#if true
		rb.AddRelativeForce(Vector3.right * horizontal * Time.fixedDeltaTime);
#endif
		rb.AddRelativeForce(Vector3.forward * vertical * Time.fixedDeltaTime);
		//rotate left and right
#if false
		rb.AddRelativeTorque(Vector3.up * horizontal * Time.fixedDeltaTime);
#endif
		//Jump
#if true
		rb.AddRelativeForce(Vector3.up * jump * Time.fixedDeltaTime);
#endif
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
