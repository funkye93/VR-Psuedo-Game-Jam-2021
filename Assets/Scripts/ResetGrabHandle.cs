using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGrabHandle : MonoBehaviour {

	public Rigidbody handler;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void ResetHandle() {
		//something in here fucks with the scale of the grab handler and idk why
		Rigidbody rbHandler = handler.GetComponent<Rigidbody>();
		rbHandler.velocity = Vector3.zero;
		rbHandler.angularVelocity = Vector3.zero;

		Debug.Log(transform.position);
		transform.position = handler.transform.position;
		transform.rotation = handler.transform.rotation;
		Debug.Log("Released handle, should reset");
		Debug.Log(transform.position);

	}
}
