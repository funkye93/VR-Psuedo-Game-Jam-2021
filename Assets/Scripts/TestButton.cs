using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestButton : MonoBehaviour {

    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;
    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    public UnityEvent onPressed;
    public UnityEvent onReleased;

	private void Start() {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
        isPressed = false;
	}

	private void Update() {
		if(!isPressed && GetVal() + threshold >= 1) {
            Pressed();
		}
        else if(isPressed && GetVal() - threshold <= 0) {
            Released();
		}
	}

    private float GetVal() {
        float value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;
        if(Mathf.Abs(value) < deadZone) {
            value = 0f;
		}
        Mathf.Clamp(value, -1f, 1f);
        return value;
	}

    private void Pressed() {
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("button pressed");
	}

    private void Released() {
        isPressed = false;
        onReleased.Invoke();
        Debug.Log("button released");
    }
}
