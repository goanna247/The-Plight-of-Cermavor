using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;

public class InGameMenu : MonoBehaviour {
  // public Canvas InGameMenu;
  // // public Text pannelext;

  // public Canvas screenImage;
  public GameObject screenImage;
  // public Text example;

  public GameObject leftController;
  public GameObject leftHighlightedController;

  private OVRManager controller;

  private bool menuToggle = true;

  void Start() {
    // example.text = "Hello world";
  }

  void Update() {
    OVRInput.Update();
    //when X button pressed display the menu 
    if (OVRInput.GetUp(OVRInput.Button.Two)) { //m key is for debugging purposes
    //  || Input.GetKeyUp("m")
      if (menuToggle) {
        menuToggle = false;
      } else {
        menuToggle = true;
      }
    }

    if (menuToggle) {
      // screenImage.enabled = true;
      screenImage.SetActive(true);
    } else {
      // screenImage.enabled = false;
      screenImage.SetActive(false);
      
    }
  }
}