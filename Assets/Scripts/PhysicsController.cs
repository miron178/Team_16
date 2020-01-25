using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
	[SerializeField]
	private float acceleration = 100000;
	private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		float horizontal = acceleration * Input.GetAxis("Horizontal");
		float vertical   = acceleration * Input.GetAxis("Vertical");

		rb.AddForce(
			Vector3.right * horizontal * Time.fixedDeltaTime +
			Vector3.forward * vertical * Time.fixedDeltaTime);
    }
}
