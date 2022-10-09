using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using static Globals;

public class Robots : MonoBehaviour {

  public GameObject robot1;
  public GameObject robot2;

  private float waitBeforeFinish = 20f;
  private float robotTimer = 0f;

  private bool collecting = false;

  void Update() {
    if (Input.GetKeyUp("r")) {
      Globals.RobotCollecting = true;
    } 


    if (Globals.RobotCollecting) {
      collecting = true;
    } else {
      collecting = false;
    }

    if (collecting) {
      robot1.SetActive(false);
      robot2.SetActive(false);
      robotTimer += Time.deltaTime;
    }

    if (robotTimer >= waitBeforeFinish) {
      robot1.SetActive(true);
      robot2.SetActive(true);
      Globals.SamplesAmount ++;
      robotTimer = 0; //reset the robot timer 
      Globals.RobotCollecting = false;
    }
  }
}