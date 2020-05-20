﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
	[SerializeField]
	private Transform des;
	private GameObject objectInRange = null;
	private GameObject holding = null;
	private int pickUpLayer;
	private int wallLayer;

	[SerializeField]
	private string prefix = "P2";

	void Start() {
		pickUpLayer = LayerMask.NameToLayer("PickUp");
		wallLayer = LayerMask.NameToLayer("Wall");
	}

	// Update is called once per frame
	void Update()
    {
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

