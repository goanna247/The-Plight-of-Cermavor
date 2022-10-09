using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using static Globals;

public class ExitUnder : MonoBehaviour {

  void OnCollisionEnter(Collision other) {
    if (other.transform.tag == "SELECTCONTROLLER") {
      SceneManager.LoadScene("MainScene");
    }
  }
}