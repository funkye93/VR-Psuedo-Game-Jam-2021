using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPillBottle : MonoBehaviour {
	public GameObject pill;
	//public GameObject pillBottle;

    public void MakePill() {
		Instantiate(pill, this.transform.position, this.transform.rotation);
	}
}
