using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using static Globals;

public class RobotMenu : MonoBehaviour {
  
  public Text RobotLevel;
  public Text CostToUpdateRobot;
  public Text Robot1Status;
  public Text Robot2Status;
  public Text TimeToCollect;
  public Text SamplesCollected;
  public Text TotalSamplesCollected;

  void Update() {
    RobotLevel.text = Globals.robotLevel.ToString();
    CostToUpdateRobot.text = "$" + Globals.costToUpdateRobot + " Mill";
    switch (Globals.robot1Status) {
      case 0: 
        Robot1Status.text = "Idle";
      break;
      case 1:
        Robot1Status.text = "Collecting";
      break;
      case 2:
        Robot1Status.text = "Finished";
      break;
    }
    switch (Globals.robot2Status) {
      case 0: 
        Robot2Status.text = "Idle";
      break;
      case 1:
        Robot2Status.text = "Collecting";
      break;
      case 2:
        Robot2Status.text = "Finished";
      break;
    }
    TimeToCollect.text = Globals.timeToCollect + " d";
    SamplesCollected.text = Globals.SamplesAmount.ToString();
    TotalSamplesCollected.text = Globals.TotalSamplesAmount.ToString();
  }

  public void RobotUpdateButton() {
    if (Globals.totalMoney >= Globals.costToUpdateRobot) {
      Globals.robotLevel ++;
      Globals.totalMoney = Globals.totalMoney - Globals.costToUpdateRobot;
    }
  }
}