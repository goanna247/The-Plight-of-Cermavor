using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Globals : MonoBehaviour {
  public const float triggerDeadzone = 0.1f; //value before the controller registers the trigger as bring pressed
  public static bool leftPressed = false; //whether the left controllers index trigger is pressed
  public static bool rightPressed = false; //whether the right controller trigger is pressed, when the controller is in non-gun form
  public static int resourcesCollected = 0; //how many resouces have been collected

  public static int day = 1;
  public static int cycle = 1;

  public static float totalMoney = 10f;
  public static float moneyThisCycle = 10f; //not currently used

  public static float profitThisCycle = 0f;
  public static float profitTotal = 0f;

  public static bool RobotCollecting = false;
  public static bool Drilling = false;

  public static int MartianRockAmount = 5;
  public static int DeepRockAmount = 0;
  public static int SamplesAmount = 0;

  public static int TotalSamplesAmount = 0;

  public static float MartianRockSellPrice = 0.4f;
  public static float DeepRockSellPrice = 0.6f;
  public static float SamplesSellPrice = 0.7f;

  public static int robotLevel = 1;
  public static float costToUpdateRobot = 0.5f;

  public static int robot1Status = 0; //0 -> idle, 1 -> collecting, 2 -> finished. 
  public static int robot2Status = 0;

  public static float timeToCollect = 0.8f;

  public static int enemyCount = 0;
  public static bool IsNight = false;

  public static bool menuOpen = false;
}