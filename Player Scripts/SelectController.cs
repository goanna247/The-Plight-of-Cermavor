using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using static Globals;

public class SelectController : MonoBehaviour {

  void Start() {

  }

  void Update() {

  }

/// When the player collides with a resource, destroy the resource and increment the resourcesCollected
/// variable
/// 
/// @param Collision The collision object that contains information about the collision.
  void OnCollisionEnter(Collision other) {
    Debug.Log(other.transform.tag);
    if (other.transform.tag == "RESOURCE") {
      Destroy(other.gameObject);
      Globals.resourcesCollected ++;
    }
  }
}