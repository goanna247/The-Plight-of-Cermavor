using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Globals : MonoBehaviour {
  public const float triggerDeadzone = 0.1f; //value before the controller registers the trigger as bring pressed
  public static bool leftPressed = false; //whether the left controllers index trigger is pressed
  public static bool rightPressed = false; //whether the right controller trigger is pressed, when the controller is in non-gun form
  public static int resourcesCollected = 0; //how many resouces have been collected
}