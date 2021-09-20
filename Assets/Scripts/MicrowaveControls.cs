using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveControls : MonoBehaviour {

	private HingeJoint hinge;
	private Rigidbody doorRigidbody;

	public GameObject door;

	public float timerLen = 3.0f;

	// Start is called before the first frame update
	void Start() {
		hinge = GetComponent<HingeJoint>();
		doorRigidbody = door.GetComponent<Rigidbody>();
	}

	public void TryStartMicrowave() {
		//if the door is basically closed
		if(Mathf.Abs(door.transform.localRotation.y) < .1f) {
			StartCoroutine(MicrowaverTimer());
			//doorRigidbody.isKinematic = true;
			//for some reason this^ and use gravity are turned to false while grabbing. Interesting.
		}
		//doorRigidbody.freezeRotation = true;
	}

	IEnumerator MicrowaverTimer() {
		Debug.Log("Microwave Locked");
		doorRigidbody.freezeRotation = true;
		Debug.Log("Y rotation: " + door.transform.localRotation.y);
		yield return new WaitForSeconds(timerLen);
		doorRigidbody.freezeRotation = false;
		Debug.Log("Microwave Unlocked");
	}


	// Update is called once per frame
	void Update() {

	}
}
