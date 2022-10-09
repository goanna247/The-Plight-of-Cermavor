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
      SceneManager.LoadScene("MainScene");
    }

    if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > Globals.triggerDeadzone) {
      MenuRightController.SetActive(false);
      MenuRightControllerSelected.SetActive(true);
    } else {
      MenuRightController.SetActive(true);
      MenuRightControllerSelected.SetActive(false);
    }

    if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > Globals.triggerDeadzone) {
      MenuLeftController.SetActive(false);
      MenuLeftControllerSelected.SetActive(true);
    } else {
      MenuLeftController.SetActive(true);
      MenuLeftControllerSelected.SetActive(false);
    }
  }
}