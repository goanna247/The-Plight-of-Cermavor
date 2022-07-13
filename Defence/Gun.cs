using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using static ControllerManager;

//also has some controller stuff here as well ♡

public class Gun : MonoBehaviour {

  private OVRManager controller;
  private InputDevice targetDevice;

  public GameObject leftDebugCube;
  public Material blue1;
  public Material green1;
  public Material pink1;
  public Material orange1;

  void Start() {

  }
  
  void Update() {
    if (ControllerManager.isGun) {
      if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.1f) {
        leftDebugCube.GetComponent<MeshRenderer>().material = green1;
      } else {
        leftDebugCube.GetComponent<MeshRenderer>().material = orange1;
      }
    }
  }
}