using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePhysics : MonoBehaviour {
	public Transform target;

	private Rigidbody rb;

	// Start is called before the first frame update
	private void Start() {
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		rb.MovePosition(target.transform.position);
	}
}
