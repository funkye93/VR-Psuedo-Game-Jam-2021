using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterControls : MonoBehaviour {
	public GameObject display;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void ToggleDisplay() {
		Debug.Log("Screen button hit");
		if(display.activeInHierarchy) {
			display.SetActive(false);
			Debug.Log("screen turned off");
		}
		else {
			display.SetActive(true);
		}
	}
}
