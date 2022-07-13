using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static Globals;


//when the user pressed the side toggle, press the front toggle to select. 

public class ControllerManager : MonoBehaviour {

  public GameObject debugCube;

  public GameObject Controller;
  public GameObject HighlightedController;
  public GameObject Gun;

  public Material blue;
  public Material green;
  public Material pink;

  private InputDevice targetDevice;

  private OVRManager controller;

  [SerializeField]
  private bool isLeft;

  public static bool isGun = false; //used in the gun toggle

  void Start() {
    Controller.SetActive(true);
    HighlightedController.SetActive(false);
    Gun.SetActive(false);

    debugCube.GetComponent<MeshRenderer> ().material = green;

    List<InputDevice> devices = new List<InputDevice>();
    InputDevices.GetDevices(devices);

    foreach (var item in devices) {
      Debug.Log(item.name + item.characteristics);
    }

    if (devices.Count > 0) {
      targetDevice = devices [0];
    } 

  }

  void Update() {
    OVRInput.Update();

    /* Checking if the user pressed the B Button and if they did, it will toggle the gun on or off. */
    if (OVRInput.GetUp(OVRInput.Button.Two)) {
      if (isGun) {
        isGun = false;
      } else {
        isGun = true;
      }
    } 

    if (!isLeft) { //if right controller script
      //if the controller is meant to be a gun the right debug cube will turn blue else it will be pink
      if (isGun) {
        debugCube.GetComponent<MeshRenderer>().material = blue;
      } else {
        debugCube.GetComponent<MeshRenderer>().material = pink;
      }
    }

    // if (OVRInput.Get(OVRInput.Button.One)) {
    //   debugCube.GetComponent<MeshRenderer> ().material = blue;
    // }

    // if (OVRInput.Get(OVRInput.RawButton.X)) {
    //   debugCube.GetComponent<MeshRenderer> ().material = pink;
    // }
    if (!isLeft) {
      if (isGun) {
        Controller.SetActive(false);
        HighlightedController.SetActive(false);
        Gun.SetActive(true);
      } else {
        Controller.SetActive(true);
        HighlightedController.SetActive(false);
        Gun.SetActive(false);
      }
    }

    if (!isGun) {
      Gun.SetActive(false);

      if (isLeft) {
        if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > Globals.triggerDeadzone) {
          Controller.SetActive(false);
          HighlightedController.SetActive(true);
          if (isLeft) {
            Globals.leftPressed = true;
          } else { 
            Globals.rightPressed = true;
          }
        } else {
          Controller.SetActive(true);
          HighlightedController.SetActive(false);
          if (isLeft) {
            Globals.leftPressed = false;
          } else { 
            Globals.rightPressed = false;
          }
        }
      } else {
        if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > Globals.triggerDeadzone) {
          Controller.SetActive(false);
          HighlightedController.SetActive(true);
          if (isLeft) {
            Globals.leftPressed = true;
          } else { 
            Globals.rightPressed = true;
          }
        } else {
          Controller.SetActive(true);
          HighlightedController.SetActive(false);
          if (isLeft) {
            Globals.leftPressed = false;
          } else { 
            Globals.rightPressed = false;
          }
        }
      }
    } 
    // else { //isGun == true
    //   Controller.SetActive(false); //TODO @Anna make a function for this so all you have to call is Controller(false, false, true);
    //   HighlightedController.SetActive(false);
    //   Gun.SetActive(true);
    // }
  }
}
