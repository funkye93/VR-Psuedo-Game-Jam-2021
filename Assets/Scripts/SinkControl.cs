using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkControl : MonoBehaviour {
	public GameObject handle;
	public GameObject water;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if(handle.transform.localRotation.y > .1f) {
			water.SetActive(true);
		}
		else {
			water.SetActive(false);
		}
	}


}
