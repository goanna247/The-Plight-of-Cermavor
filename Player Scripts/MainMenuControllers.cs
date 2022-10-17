using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static Globals;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenuControllers : MonoBehaviour {
  public GameObject MenuLeftController;
  public GameObject MenuLeftControllerSelected;

  public GameObject MenuRightController;
  public GameObject MenuRightControllerSelected;

  private InputDevice targetDevice;

  void Start() {
    MenuLeftController.SetActive(true);
    MenuLeftControllerSelected.SetActive(false);
    MenuRightController.SetActive(true);
    MenuRightControllerSelected.SetActive(false);
  }

  void Update() {
    OVRInput.Update();

    if (OVRInput.GetUp(OVRInput.Button.Two)) {
      LoadMainScene();
    }

    if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > Globals.triggerDeadzone) {
      SetControllersActive(false, false, true);
    } else {
      SetControllersActive(false, true, false);
    }

    if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > Globals.triggerDeadzone) {
      SetControllersActive(true, false, true);
    } else {
      SetControllersActive(true, true, false);
    }
  }

  void SetControllersActive(bool leftController, bool ControllerActive, bool ControllerSelectedActive) {
    if (leftController) {
      MenuLeftController.SetActive(ControllerActive);
      MenuLeftControllerSelected.SetActive(ControllerSelectedActive);
    } else {
      MenuRightController.SetActive(ControllerActive);
      MenuRightControllerSelected.SetActive(ControllerSelectedActive);
    }
  }

  void LoadMainScene() {
    SceneManager.LoadScene("MainScene");
  }
}