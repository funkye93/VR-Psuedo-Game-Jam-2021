using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleGrabInteractable : XRGrabInteractable { 

	public Transform handler;

	public void ForceDrop() {
#pragma warning disable CS0618 // Type or member is obsolete
		OnSelectExited(selectingInteractor);
#pragma warning restore CS0618 // Type or member is obsolete
		transform.position = handler.transform.position;
		transform.rotation = handler.transform.rotation;
	}

	public void ResetGrabHandle() {
		Rigidbody rbHandler = handler.GetComponent<Rigidbody>();
		rbHandler.velocity = Vector3.zero;
		rbHandler.angularVelocity = Vector3.zero;

		transform.position = handler.transform.position;
		transform.rotation = handler.transform.rotation;


	}

	private void Update() {
		if(Vector3.Distance(handler.transform.position,transform.position) > 0.4f) {
			ForceDrop();
		}
	}
}
