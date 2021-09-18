using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour {
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    // Start is called before the first frame update
    void Start() {
        TryInitialize();
    }

    void TryInitialize() {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if(devices.Count > 0) {
            targetDevice = devices[0];
            Debug.Log(targetDevice.name + targetDevice.characteristics);
            GameObject controlPrefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if(controlPrefab) {
                spawnedController = Instantiate(controlPrefab, transform);
            }
            else {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }

    void UpdateHandAnimation() {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerVal)) {
            handAnimator.SetFloat("Trigger", triggerVal);
		}
        else {
            handAnimator.SetFloat("Trigger", 0);
        }

        if(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripVal)) {
            handAnimator.SetFloat("Grip", gripVal);
		}
        else {
            handAnimator.SetFloat("Grip", 0);
        }
	}

    // Update is called once per frame
    void Update() {
        if(!targetDevice.isValid) {
            TryInitialize();
		}
        else {
            if(showController) {
                spawnedController.SetActive(true);
                spawnedHandModel.SetActive(false);
            }
            else {
                spawnedController.SetActive(false);
                spawnedHandModel.SetActive(true);
                UpdateHandAnimation();
            }
        }
    }
}
