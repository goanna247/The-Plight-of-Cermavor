using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Materials : MonoBehaviour {

  private float speed = 1f; //the speed the material moves up and down
  private float height = 0.2f; //the distance the material moves 

  private float currentX; //defining the X position when the object spawns
  private float currentZ;//defining the Z position when the object spawns

/// This function is called when the script is first loaded. It stores the current position of the
/// object in the variables currentX and currentZ
  void Start() {
    currentX = transform.position.x;
    currentZ = transform.position.z;
  }

/// The function Update() is called every frame. It takes the current position of the object, and then
/// moves it up and down based on the sine of the time multiplied by the speed
  void Update() {
    Vector3 pos = transform.position;
    float newY = Mathf.Sin(Time.time * speed);
    gameObject.transform.position = new Vector3(currentX, newY + 2f, currentZ) * height;
  }
}