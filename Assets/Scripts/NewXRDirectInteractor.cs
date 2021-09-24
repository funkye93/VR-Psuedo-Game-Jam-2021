using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NewXRDirectInteractor : XRDirectInteractor {

	// Update is called once per frame
	void Update() {
		if(selectTarget != null && allowSelect == true) {
			if(Vector3.Distance(transform.position, selectTarget.transform.position) > 0.6f) {
				Debug.Log("DROP IT");

				allowSelect = false;
			}

		}
	}
}
