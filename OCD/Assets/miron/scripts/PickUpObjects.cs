using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
	[SerializeField]
	private Transform des;
	private GameObject objectInRange = null;
	private GameObject holding = null;
	private int pickUpLayer;

	void Start() {
		pickUpLayer = LayerMask.NameToLayer("PickUp");
	}

	// Update is called once per frame
	void Update()
    {
		//pick up
		if (Input.GetKey(KeyCode.E) && !holding && objectInRange) {
			PickUp(objectInRange);
			holding = objectInRange;
			objectInRange = null;
		}

		//drop
		if (Input.GetKey(KeyCode.R) && holding) {
			Drop(holding);
			objectInRange = holding;
			holding = null;
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

