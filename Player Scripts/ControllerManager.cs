using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static Globals;


//when the user pressed the side toggle, press the front toggle to select. 

public class ControllerManager : MonoBehaviour {

  public GameObject leftDebugCube; //the left debug cube object, used only for debugging purposes
  public GameObject rightDebugCube; // the right debug cube object, used only for debugging purposes

  public GameObject LeftController; //the left controller prefab
  public GameObject LeftHighlightedController; //the left controller highlighted prefab (features a purple strip around the top)

  public GameObject RightController;//the right controller prefab
  public GameObject RightHighlightedController;//the right controller highlighted prefab (features a purple strip around the top)

  public GameObject SitCannon; //the sit cannon prefab

  public GameObject Gun; // the gun prefab 

  public Material blue; // blue material
  public Material green; //green material
  public Material pink; //pink material

  private InputDevice targetDevice; //the target device of the controller

  private OVRManager controller; //the controller manager 

  private GameObject SitCannonInstance; //the instance of the sit cannon

  public static bool isGun = false; //used in the gun toggle

  Vector3 upwards; //vector that stores the upwards position 

  /// We're setting up the controllers, the gun, and the debug cubes. We're also setting up a list of
  /// input devices and a vector3 called upwards.
  void Start() {
    LeftController.SetActive(true);
    LeftHighlightedController.SetActive(false);
    RightController.SetActive(true);
    RightHighlightedController.SetActive(false);
    Gun.SetActive(false);

    leftDebugCube.GetComponent<MeshRenderer>().material = pink;
    rightDebugCube.GetComponent<MeshRenderer>().material = pink;

    List<InputDevice> devices = new List<InputDevice>();
    InputDevices.GetDevices(devices);

    upwards = new Vector3(0.0f, 1.0f, 0.0f);  
  }

 /// This function is called every frame and it checks if the user pressed the B button on the right
 /// controller and if they did, it will toggle the gun on or off. If the gun is on, it will disable the
 /// right controller and enable the gun. If the gun is off, it will enable the right controller and
 /// disable the gun. It also checks if the user is pressing the trigger on the left controller and if
 /// they are, it will disable the left controller and enable the highlighted left controller. If the
 /// user is not pressing the trigger, it will enable the left controller and disable the highlighted
 /// left controller. It also checks if the user pressed the Y button on the right controller or the B
 /// key on the keyboard and if they did, it will instantiate a cannon
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

    if (isGun) {
      leftDebugCube.GetComponent<MeshRenderer>().material = blue;
    } else {
       leftDebugCube.GetComponent<MeshRenderer>().material = green;
    }

    if (isGun) {
      RightController.SetActive(false);
      RightHighlightedController.SetActive(false);
      Gun.SetActive(true);
    } else {
      Gun.SetActive(false);
    }

    if (!isGun) {
      if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > Globals.triggerDeadzone) {
        RightController.SetActive(false);
        RightHighlightedController.SetActive(true);
        Globals.rightPressed = true;
      } else {
        RightController.SetActive(true);
        RightHighlightedController.SetActive(false);
        Globals.rightPressed = false;
      }
    }

    if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > Globals.triggerDeadzone) {
      LeftController.SetActive(false);
      LeftHighlightedController.SetActive(true);
      Globals.leftPressed = true;
    } else {
      LeftController.SetActive(true);
      LeftHighlightedController.SetActive(false);
      Globals.leftPressed = false;
    }

    if (OVRInput.GetUp(OVRInput.Button.Four) || Input.GetKeyUp("b")) {
      SitCannonInstance = Instantiate(SitCannon, gameObject.transform.position + upwards, Quaternion.identity);
    }
  }
}
