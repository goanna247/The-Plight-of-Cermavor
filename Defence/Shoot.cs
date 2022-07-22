using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//object on the bullet being shot by the players handgun

public class Shoot : MonoBehaviour {
  public float shootDestructionTime = 2f; //the amount of time before the bullet is destroyed
  public float shootTimer = 0; //timer that keeps track of how long the bullet has been active for

  public float applyShootDamage = 5f;//how much damage the bullet applies 

  /// The function Update() is called every frame. It increments the shootTimer by the amount of time
  /// that has passed since the last frame. If the shootTimer is greater than or equal to the
  /// shootDestructionTime, the gameObject is destroyed
  void Update() {
    shootTimer += Time.deltaTime;

    if (shootTimer >= shootDestructionTime) {
      Destroy(gameObject);
    }
  }

/// If the bullet hits something that isn't tagged as "Untagged", destroy the bullet. If the bullet hits
/// something that is tagged as "ENEMY", apply damage to the enemy
/// 
/// @param Collision The collision that the bullet has hit
  void OnCollisionEnter(Collision other) {
    if (other.transform.tag != "Untagged") {
      Destroy(gameObject);
    }

    if (other.transform.tag == "ENEMY") {
      other.gameObject.GetComponent<HealthScript>().ApplyDamage(20f); //TODO Change this to the variable
    }
  }
}