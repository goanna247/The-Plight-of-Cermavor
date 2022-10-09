using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using static Globals;
using TMPro;
using System;


public class BasicMenu : MonoBehaviour {
  
  public TMP_Text dayText;
  public TMP_Text resourcesText;

  void Start() {

  }

  void Update() {
    if (Globals.menuOpen) {
      dayText.SetText((Globals.day).ToString());
      resourcesText.SetText((Globals.MartianRockAmount).ToString());
    } else {
      dayText.SetText(" ");
      resourcesText.SetText(" ");
    }
  }
}