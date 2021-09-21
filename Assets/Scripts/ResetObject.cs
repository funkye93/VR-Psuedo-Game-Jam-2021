using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour {
	private Vector3 startingPos;
	private Quaternion startingRot;

	public LayerMask interactingLayer;
	public bool destroyInstead = false;

	// Start is called before the first frame update
	void Start() {
		startingPos = gameObject.transform.position;
		startingRot = gameObject.transform.rotation;
		//Debug.Log("Colliding 8: " + ((1 << 8 & interactingLayer) == 1));
		//Debug.Log("Colliding 7: " + ((1 << 8 & interactingLayer) == 1));
		Debug.Log(1 << 8);
		Debug.Log(interactingLayer.value);
	}

	// Update is called once per frame
	void Update() {

	}

	private void OnTriggerEnter(Collider other) {
		//8 is Mouth layer, 9 is Destroy layer
		//apparently we have to use bitwise operation to figure out which layers are in a layer mask
		//basically if Xth bit in interactingLayer is 1, there was a collision we care about
		if(((interactingLayer >> other.gameObject.layer) & 1) == 1) {
			if(destroyInstead) {
				Destroy(gameObject);
			}
			else {
				gameObject.transform.position = startingPos;
				gameObject.transform.rotation = startingRot;
			}
		} 
	}
}
